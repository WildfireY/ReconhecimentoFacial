using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Reconhecimento_Facial_Trab.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Emgu.CV.Face.FaceRecognizer;
using System.IO;

namespace Reconhecimento_Facial_Trab
{
    public partial class FmrPrincipal : Form
    {

        CascadeClassifier cascade;

        VideoCapture capture;

        FaceRecognizer faceRecognizer;

        List<Mat> lstCaptura;
        List<int> lstID;
        List<String> lstNome;
        int ID = 0;
        public FmrPrincipal()
        {
            InitializeComponent();
            faceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 100);
            capture = new VideoCapture(0);
            lstCaptura = new List<Mat>();
            lstID = new List<int>();
            lstNome = new List<string>();
            // Instancia de um CascadeClassifier apontando para um arquivo treinado para reconhecer face
            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                cascade = new CascadeClassifier(projectDirectory + @"\Reconhecimento_Facial_Trab\Utils\haarcascade_frontalface_default.xml");
            }
            catch (Exception ex)
            {
                tmrFoto.Stop();
                new frmErro(ex).ShowDialog();
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCadastro.Text.Trim()))
            {
                MessageBox.Show("Preencha o campo Nome!");
            }
            else
            {
                Treinamento();
            }
        }
        public void Treinamento()
        {
            tmrFoto.Stop();
            try
            {
                ID++;
                for (int i = 0; i < 30; i++)
                {
                    Mat captura = capture.QueryFrame();
                    Image<Gray, byte> grayFrame = captura.ToImage<Gray, byte>();
                    Rectangle[] faces = cascade.DetectMultiScale(grayFrame, 1.4, 4, new Size(30, 30), new Size(400, 400));
                    if (faces != null && faces.Length > 0)
                    {
                        grayFrame = grayFrame.Copy(faces[0]);

                        lstNome.Add(txtCadastro.Text);
                        lstID.Add(ID);
                        lstCaptura.Add(grayFrame.Mat);
                        System.Threading.Thread.Sleep(200);
                    }
                }
                faceRecognizer.Train(lstCaptura.ToArray(), lstID.ToArray());
                tmrFoto.Start();
                txtCadastro.Text = String.Empty;

                MessageBox.Show("Cadastrado com sucesso!!!!");
            }
            catch (Exception ex)
            {
                new frmErro(ex).ShowDialog();
            }
        }
        private void tmrFoto_Tick(object sender, EventArgs e)
        {
            CarregarImagem();
        }

        public void CarregarImagem()
        {
            try
            {
                Mat matOriginal = capture.QueryFrame();

                Image<Gray, byte> grayFrame = matOriginal.ToImage<Gray, byte>(); // transforma o Mat em um frame em tons de cinza
                Image<Bgr, byte> bgrFrame = matOriginal.ToImage<Bgr, byte>(); // transforma o Mat em um frame em cores

                // Procura por faces na imagem. Para cada face encontrada, um objeto Rectangle com dados da face (posição na
                // imagem, tamanho) é retornado. Por isso, o método retorna um vetor de Rectangle (um para cada face)
                Rectangle[] faces = cascade.DetectMultiScale(grayFrame, 1.4, 4, new Size(30, 30), new Size(400, 400));

                // Vamos trabalhar APENAS com a primeira face (Rectangle) encontrada (se houver mais de uma, as demais serão descartadas)
                // Caso voce queira detectar mais de uma, basta trabalhar com vetor inteiro (todas os Rectangles).

                if (faces != null && faces.Length > 0) // Se houve apenas uma Rectangle detectado
                {
                    bgrFrame.Draw(faces[0], new Bgr(255, 0, 0), 2); // Desenha o retangulo verde na imagem
                    grayFrame = grayFrame.Copy(faces[0]);
                    if (lstCaptura.Count > 0)
                    {
                        PredictionResult resultado = faceRecognizer.Predict(grayFrame);

                        if (resultado.Distance < 30)
                        {
                            bgrFrame.Draw("Nome: " + lstNome[lstID.IndexOf(resultado.Label)],
                                    new Point(faces[0].X-5, faces[0].Y-5),
                                    FontFace.HersheySimplex,
                                    1,
                                    new Bgr(255, 0, 0),
                                    2);
                        }
                    }
                    pcbRecortada.Image = bgrFrame.Copy(faces[0]).ToBitmap(); // Recorta a face da imagem e atribui o recorte para a picturebox de face recortada
                }
                else
                {
                    pcbFoto.Image = null; // caso não houver, limpa a picturebox de face recortada
                }

                pcbFoto.Image = bgrFrame.ToBitmap(); // aribui a imagem do frame em cores para a picturebox de imagem original 
            }
            catch (NotSupportedException)
            {
                tmrFoto.Stop();
                MessageBox.Show("Por favor ligue a Câmera e Reinicie o aplicativo!!!");
                Application.Exit();
            }
            catch (Exception ex)
            {
                tmrFoto.Stop();
                new frmErro(ex).ShowDialog();
            }
        }
    }
}