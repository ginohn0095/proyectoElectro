using System;
using System.Windows.Forms;

namespace proyectoElectro
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBoxQRCode;

        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Instancia de la clase QRCodeGenerator
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // El texto que quieres codificar en el QR
            string inputText = "Texto para el código QR";

            // Llamar al método para generar el QR pasando el PictureBox por referencia
            qrGenerator.GenerateQRCode(inputText, ref pictureBoxQRCode);
        }
    }
}