using System.Drawing;

namespace proyectoElectro
{
    public class QRCodeRenderer
    {
        public Bitmap Render(int[,] qrMatrix, int scale)
        {
            int size = qrMatrix.GetLength(0);
            Bitmap bitmap = new Bitmap(size * scale, size * scale);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White); // Fondo blanco

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (qrMatrix[i, j] == 1)
                        {
                            graphics.FillRectangle(Brushes.Black, j * scale, i * scale, scale, scale);
                        }
                    }
                }
            }

            return bitmap;
        }
    }
}