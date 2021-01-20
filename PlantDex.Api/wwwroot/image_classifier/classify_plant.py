import os
import tensorflow as tf
from tensorflow.keras.preprocessing.image import ImageDataGenerator  # for preprocessing
from tensorflow.keras.models import Sequential

os.chdir('wwwroot/image_classifier')

#identified plants
classes = ['Jao Costus spiralis', 'Jao Duranta erecta',
           'Jao Ficus microcarpa', 'Jao Plant 1',
           'Jao Plant 3', 'Jao Tradescantia zebrina',
           'Rad Bamboo', 'Rad Calamasi',
           'Rad Guyabano', 'Rad Indian Mango',
           'Rad Langka', 'Rad P6',
           'Rad STAR APPLE', 'plant1_cropped',
           'plant2_cropped', 'plant3_cropped',
           'plant4_cropped', 'plant5_cropped',
           'plant6_cropped', 'plant7_cropped']


#returns the index of the largest value in the given array
def max(arr):
  max = arr[0]
  ind = 0
  for i in range(len(arr)):
    if(arr[i] > max):
       max = arr[i]
       ind = i
  return ind


#creates the classifier's prediction function
def tf_classifier():

    #image pre-processing
    classify_dataset_directory = 'classify'
    IMG_height = 200
    IMG_width = 200
    training_batch_size = 1
    train_class_mode = 'categorical'
    classify = ImageDataGenerator(rescale=1/255)

    #init classifier arguments
    classify_dataset = classify.flow_from_directory(
        classify_dataset_directory,
        target_size=(IMG_height, IMG_width),
        batch_size=training_batch_size,
        class_mode=train_class_mode,
        shuffle=False)

    #init trained model
    model = tf.keras.models.load_model('saved_model/my_model')

    #init classifier's prediction function
    preds = model.predict(classify_dataset)
    return preds


#Goes to the que folder and finds the first file alphabetically
os.chdir("que")
to_classify = os.listdir()[0]
os.chdir("../")


#this moves the file to the ICU
#the ICU is where the classifications happen
os.rename("que/"+to_classify, "classify/ICU/"+to_classify)

#this classifies the image
preds = tf_classifier()[0]
classs = str(classes[max(preds)]) + ":" + str(preds[max(preds)]) + ","
k = max(preds)
preds[k] = -1

classs = classs + str(classes[max(preds)]) + ":" + str(preds[max(preds)]) + ","
preds[max(preds)] = -1

classs = classs + str(classes[max(preds)]) + ":" + str(preds[max(preds)]) + ","
preds[max(preds)] = -1


#this moves the file from the ICU to the done folder
os.rename("classify/ICU/"+to_classify, "done/"+to_classify)

print(classs)