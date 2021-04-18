using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using Emgu.CV;
using System.IO.Ports;


namespace facialRecon
{
    public partial class Form1 : Form
    {
        #region Variables

        private Capture cap = null;
        private Image<Bgr, Byte> currentFrame = null;
        private Mat frame = new Mat();
        private int posx, posy, scale = 2;


        static SerialPort port;

        private bool facesDetectionEnable = false;
        private bool repositionningEnable = false;
        CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void StartCapture_Click(object sender, EventArgs e)
        {
            cap = new Capture();
            cap.ImageGrabbed += ProcessFrame;
            cap.Start();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            cap.Retrieve(frame, 0);
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height,Inter.Cubic);//save frame to captured size

            if(facesDetectionEnable)
            {
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray); // set image to gray for better detection
                CvInvoke.EqualizeHist(grayImage, grayImage); //brighter n more contrast
                Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayImage, scale, 3, Size.Empty, Size.Empty);//find face in image

                if (faces.Length > 0)
                {
                    // get x,y pos of the center of detected faces  
                    posx = faces.ElementAt(0).Width / 2;
                    posy = faces.ElementAt(0).Height / 2;

                    foreach (var face in faces)
                    {
                        CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Blue).MCvScalar, 2); //draw rectangle in window
                    }

                    if (repositionningEnable)
                    {
                        // setup communication w/ arduino
                        port = new SerialPort();
                        port.PortName = "COM4";
                        port.BaudRate = 9600;
                        port.Open();

                        //send face pos to arduino
                        port.Write("x" + posx);
                        port.Write("y" + posy);
                    }
                }

                Console.WriteLine(" FacePos: " + posx + " " + posy);
            }

            picCapture.Image = currentFrame.Bitmap;
        }

        private void btnDetectFace_Click(object sender, EventArgs e)
        {
            facesDetectionEnable = true;
        }

        private void btnRepositionning_Click(object sender, EventArgs e)
        {
            repositionningEnable = true;
        }
    }
}
