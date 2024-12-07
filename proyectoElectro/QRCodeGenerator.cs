using System;
using System.Drawing;
using System.Windows.Forms;

public class QRCodeGenerator
{
    // Método principal para generar el código QR
    public void GenerateQRCode(string inputText, ref PictureBox pictureBoxQRCode)
    {
        try
        {
            int size = 21; // Tamaño del QR (esto puede variar dependiendo de la cantidad de datos)

            // Inicializamos la matriz QR
            int[,] qrMatrix = new int[size, size];

            // Llenamos la matriz con los valores del código QR
            FillQRCodeMatrix(qrMatrix, inputText);

            // Verificamos las celdas reservadas (patrones de búsqueda)
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (IsReserved(qrMatrix, x, y))
                    {
                        qrMatrix[x, y] = 1; // Marcamos las celdas reservadas (color negro)
                    }
                }
            }

            // Generamos la imagen y asignamos al PictureBox
            DisplayQRCode(qrMatrix, ref pictureBoxQRCode);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error generando el código QR: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Método para llenar la matriz QR con valores (esto es solo un ejemplo básico)
    private void FillQRCodeMatrix(int[,] qrMatrix, string inputText)
    {
        int size = qrMatrix.GetLength(0);
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                qrMatrix[x, y] = (x + y) % 2 == 0 ? 1 : 0; // Alternancia simple (solo ejemplo)
            }
        }
    }

    // Método que verifica si la celda está reservada (parte de los patrones de búsqueda)
    private bool IsReserved(int[,] qrMatrix, int x, int y)
    {
        int size = qrMatrix.GetLength(0);

        // Verificamos que las celdas estén dentro de los límites de la matriz
        if (x < 0 || x >= size || y < 0 || y >= size)
        {
            return true;
        }

        // Revisamos si la celda está en las zonas reservadas (patrones de búsqueda)
        return (x < 7 && y < 7) ||
               (x >= size - 7 && y < 7) ||
               (x < 7 && y >= size - 7);
    }

    // Método para crear la imagen del QR y asignarla al PictureBox
    private void DisplayQRCode(int[,] qrMatrix, ref PictureBox pictureBoxQRCode)
    {
        int size = qrMatrix.GetLength(0);

        // Creamos una imagen de tipo Bitmap para mostrar el QR
        Bitmap qrImage = new Bitmap(size * 10, size * 10); // Escalamos la imagen (10 píxeles por celda)

        // Dibujamos la matriz en el Bitmap
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                // Usamos blanco o negro dependiendo del valor de la matriz
                Color color = qrMatrix[x, y] == 1 ? Color.Black : Color.White;
                qrImage.SetPixel(x * 10, y * 10, color); // Ajuste de escala
            }
        }

        // Asignamos la imagen generada al PictureBox
        pictureBoxQRCode.Image = qrImage;
    }
}