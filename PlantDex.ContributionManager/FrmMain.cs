using OfficeOpenXml;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void ClearForms()
        {
            foreach(var frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void viewContributionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContributions frm = new FrmContributions();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.MdiParent = this;
            frm.Show();
        }

        private List<ContributionSubmission> LoadContributions()
        {
            List<ContributionSubmission> contributions = new List<ContributionSubmission>();

            try
            {
                using (SqlConnection con = ClsConnection.GetConnection())
                {
                    SqlCommand com = new SqlCommand("SELECT * FROM dbo.VerifiedContributionSubmissions ORDER BY CAST(Timestamp as datetime) DESC", con);
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contributions.Add(new ContributionSubmission
                            {
                                CommonName = reader["CommonName"].ToString(),
                                ScientificName = reader["ScientificName"].ToString(),
                                Remarks = reader["Remarks"].ToString(),
                                Locations = reader["Locations"].ToString(),
                                Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                SubmittedImage = (byte[])reader["SubmittedImage"]
                            });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return contributions;
        }
        
        private void DeleteVerifiedSubmission()
        {
            try
            {
                using(SqlConnection con = ClsConnection.GetConnection())
                {
                    SqlCommand com = new SqlCommand("DELETE FROM VerifiedContributionSubmissions", con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted Verified Submissions");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDeleteAllVerifiedContributionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo info = System.IO.Directory.CreateDirectory(@"C:\PlantDexContributionManager");
            }catch(Exception ex)
            {
                MessageBox.Show("Please try running program as administrator");
                return;
            }

            string savePath = @"C:\PlantDexContributionManager\verifiedSubmissions" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            ExcelPackage excel = new ExcelPackage();

            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

            workSheet.Cells[1, 1].Value = "#";
            workSheet.Cells[1, 2].Value = "Id";
            workSheet.Cells[1, 3].Value = "Scientific Name";
            workSheet.Cells[1, 4].Value = "Common Name";
            workSheet.Cells[1, 5].Value = "Remarks";
            workSheet.Cells[1, 6].Value = "Locations";
            workSheet.Cells[1, 7].Value = "Timestamp";


            int ctr = 2;
            foreach(var item in LoadContributions())
            {
                workSheet.Cells[ctr, 1].Value = (ctr - 1).ToString();
                workSheet.Cells[ctr, 2].Value = item.Id.ToString();
                workSheet.Cells[ctr, 3].Value = item.ScientificName;
                workSheet.Cells[ctr, 4].Value = item.CommonName;
                workSheet.Cells[ctr, 5].Value = item.Remarks;
                workSheet.Cells[ctr, 6].Value = item.Locations;
                workSheet.Cells[ctr, 7].Value = item.Timestamp.ToString("yyyy-MM-dd hh:mm tt");

                ctr++;
            }

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();

            FileStream objFileStrm = File.Create(savePath);
            objFileStrm.Close();

            // Write content to excel file 
            File.WriteAllBytes(savePath, excel.GetAsByteArray());
            //Close Excel package
            excel.Dispose();
            MessageBox.Show("Successfully Exported Data to '" + savePath + "'");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void deleteVerifiedSubmissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteVerifiedSubmission();
        }
    }
}
