using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantDex.ContributionManager
{
    public partial class FrmContributions : Form
    {
        private string sContribution = null;
        private List<ContributionSubmission> contributions;
        public FrmContributions()
        {
            InitializeComponent();
        }

        private void FrmContributions_Load(object sender, EventArgs e)
        {
            LoadContributions();
        }

        private void LoadContributions()
        {
            contributions = new List<ContributionSubmission>();
            using(SqlConnection con = ClsConnection.GetConnection())
            {
                SqlCommand com = new SqlCommand("SELECT * FROM dbo.ContributionSubmissions ORDER BY CAST(CreatedOn as datetime) ASC", con);
                using(SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contributions.Add(new ContributionSubmission
                        {
                            CommonName = reader["CommonName"].ToString(),
                            ScientificName = reader["ScientificName"].ToString(),
                            Remarks = reader["Remarks"].ToString(),
                            Locations = reader["Locations"].ToString(),
                            SubmittedImage = (byte[])reader["SubmittedImage"],
                            Id = Convert.ToInt32(reader["Id"].ToString())
                        });
                    }
                }
            }
            gridContributions.DataSource = contributions;
        }

        private void ResetView()
        {
            sContribution = null;
            LoadSelectedContribution(null);
            LoadContributions();
        }

        private void LoadSelectedContribution(ContributionSubmission contributionSubmission)
        {

            if(contributionSubmission == null)
            {
                imgPlant.Image = null;
                lblScientificName.Text = string.Empty;
                lblCommonName.Text = string.Empty;
                txtLocation.Text = string.Empty;
                btnDelete.Enabled = false;
                btnApprove.Enabled = true;
                return;
            }

            using(var stream = new MemoryStream(contributionSubmission.SubmittedImage))
            {
                imgPlant.Image = Image.FromStream(stream);
            }

            lblScientificName.Text = contributionSubmission.ScientificName;
            lblCommonName.Text = contributionSubmission.CommonName;

            List<LocationPoint> locations = JsonConvert.DeserializeObject<List<LocationPoint>>(contributionSubmission.Locations);

            btnApprove.Enabled = true;
            btnDelete.Enabled = true;
            
            if (locations == null) return;

            locations.ForEach(x =>
            {
                txtLocation.Text = $"({x.locationName},{x.longitude},{x.latitude})\n";
            });
            
        }

        private void gridContributions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sContribution != gridContributions.CurrentRow.Cells["Id"].Value.ToString())
            {
                sContribution = gridContributions.CurrentRow.Cells["Id"].Value.ToString();
                gridContributions.CurrentRow.Selected = true;
                LoadSelectedContribution(contributions.ElementAt(gridContributions.CurrentRow.Index));
            }
            else
            {
                gridContributions.CurrentRow.Selected = false;
                LoadSelectedContribution(null);
            }
        }

        private void ApproveSubmission(ContributionSubmission contribution)
        {
            if(contribution == null)
            {
                MessageBox.Show("Please select submission!");
                return;
            }

            try
            {
                using (SqlConnection con = ClsConnection.GetConnection())
                {
                    SqlCommand com = new SqlCommand("INSERT INTO dbo.VerifiedContributionSubmissions(ScientificName, CommonName, Remarks, Locations, Timestamp) " +
                        "VALUES(@ScientificName, @CommonName, @Remarks, @Locations, GETDATE())", con);

                    com.Parameters.AddWithValue("@ScientificName", contribution.ScientificName);
                    com.Parameters.AddWithValue("@CommonName", contribution.CommonName);
                    com.Parameters.AddWithValue("@Remarks", contribution.Remarks);
                    com.Parameters.AddWithValue("@Locations", contribution.Locations);
                    com.ExecuteNonQuery();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Successfully Approved Submission");
            DeleteSubmission();
        }

        private void DeleteSubmission()
        {
            if (string.IsNullOrEmpty(sContribution))
            {
                MessageBox.Show("Please select as submission");
                return;
            }

            try
            {
                using(SqlConnection con = ClsConnection.GetConnection())
                {
                    SqlCommand com = new SqlCommand("DELETE FROM ContributionSubmissions WHERE Id = @Id", con);
                    com.Parameters.AddWithValue("@Id", sContribution);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted Record!");
                    ResetView();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ContributionSubmission submission = contributions.Where(x => x.Id == Convert.ToInt32(sContribution)).FirstOrDefault();
            string location = string.Empty;

            List<LocationPoint> points = JsonConvert.DeserializeObject<List<LocationPoint>>(submission.Locations);

            if(points != null)
            {
                points.ForEach(x =>
                {
                    location += $"({x.locationName},{x.longitude},{x.latitude})\n";
                });
                submission.Locations = location;
            }
            else
            {
                submission.Locations = "No Locations";
            }

            ApproveSubmission(submission);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSubmission();
        }
    }
}
