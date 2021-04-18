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
        Mat frame = new Mat();
        public Point facePos;
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
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height,Inter.Cubic);

            if(facesDetectionEnable)
            {
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(grayImage, grayImage);
                Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);

                Size s = grayImage.Size;
                facePos = new Point(s.Width / 2, s.Height / 2);

                if (faces.Length > 0)
                {
                    foreach(var face in faces)
                    {
                        CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Blue).MCvScalar, 2);

                        Console.WriteLine(" FacePos: " + facePos.x + " "+ facePos.y);
                        
                    }
                }
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
