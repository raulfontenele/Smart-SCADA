using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MathNet.Numerics.LinearAlgebra;
using System.Collections;


namespace Supervisoria___tcc
{
    class MLP
    {
        private int nMaxEpocas;
        private int nNeuroniosSaida;
        private float taxaDeAprendizado;
        private double precisao;
        
        public MLP(int[] tamanho)
        {
            int[] camadas = new int[] { 3, 2, 6 };

            int epocas = 0;

            int nAmostras = 10;

            double precisao = 0.00001;

            double taxaAprendizado = 0.1;

            double[] eqm = new double[] { 0, 1.000001 };

            double squareError = 0;

            double[] vetorEntrada = new double[] { 3, 3, 3, 6, 7, 8 };
            Matrix<double> vetEntrada = Matrix<double>.Build.Dense(6, 1, vetorEntrada);

            double[] vetSaida = new double[] { 1, 0 };
            Matrix<double> vetorGabarito = Matrix<double>.Build.Dense(2, 1, vetSaida);

            int tamanhoSaida = 2;

            Random rand = new Random();

            //Criando arrayList
            ArrayList weigth = new ArrayList();
            ArrayList I = new ArrayList();
            ArrayList Y = new ArrayList();
            ArrayList gradient = new ArrayList();
            ArrayList accumulator = new ArrayList();

            //Criando matrizes de pesos
            //Criando primeira matriz de pesos
            Matrix<double> w1 = Matrix<double>.Build.Dense(camadas[0], vetorEntrada.Length + 1);
            accumulator.Add(w1);
            for (var line = 0; line < w1.RowCount; line++)
            {
                for (var col = 0; col < w1.ColumnCount; col++) w1[line, col] = rand.NextDouble() - 0.5;
            }
            weigth.Add(w1);

            //Criando matrizes intermediárias
            for (var index = 1; index < camadas.Length; index++)
            {
                Matrix<double> w2 = Matrix<double>.Build.Dense(camadas[index], camadas[index - 1] + 1);
                accumulator.Add(w2);
                for (var line = 0; line < w2.RowCount; line++)
                {
                    for (var col = 0; col < w2.ColumnCount; col++) w2[line, col] = rand.NextDouble() - 0.5;
                }
                weigth.Add(w2);
            }

            //Criando ultima matriz de pesos
            Matrix<double> w3 = Matrix<double>.Build.Dense(camadas[camadas.Length - 1], tamanhoSaida);
            accumulator.Add(w3);
            for (var line = 0; line < w3.RowCount; line++)
            {
                for (var col = 0; col < w3.ColumnCount; col++) w3[line, col] = rand.NextDouble() - 0.5;
            }
            weigth.Add(w3);

            //Criando as matrizes de I , Y e Gradient
            Matrix<double> Ient = Matrix<double>.Build.Dense(vetorEntrada.Length + 1, 1);

            for (var index = 0; index <= camadas.Length; index++)
            {
                Matrix<double> In = Matrix<double>.Build.Dense(camadas[index], 1);
                Matrix<double> Yn = Matrix<double>.Build.Dense(camadas[index] + 1, 1);
                I.Add(In);
                gradient.Add(In);
                Y.Add(Yn);
            }

            do
            {
                //Zerar o acumulador
                for (int ctr = 0; ctr < camadas.Length + 1; ctr++)
                {
                    Matrix<double> aux = (Matrix<double>)accumulator[ctr];
                    aux.Clear();
                }

                eqm[0] = eqm[1];

                //Para todas as amostras
                for (var amostra = 1; amostra <= nAmostras; amostra++)
                {

                    //FeedFoward
                    for (int ctr = 0; ctr < camadas.Length + 1; ctr++)
                    {
                        if (ctr == 0)
                        {
                            I[ctr] = (Matrix<double>)weigth[ctr] * vetEntrada;
                            Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));
                        }
                        else if (ctr == camadas.Length)
                        {
                            I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)I[ctr - 1];
                            Y[ctr] = Matrix<double>.Tanh((Matrix<double>)I[ctr]);
                        }
                        else
                        {
                            I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)I[ctr - 1];
                            Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));
                        }
                    }

                    //Backward
                    for (int ctr = camadas.Length; ctr >= 0; ctr--)
                    {
                        if (ctr == camadas.Length)
                        {
                            gradient[ctr] = Matrix<double>.op_DotMultiply(vetorGabarito.Transpose() - (Matrix<double>)Y[ctr], (Matrix<double>)derTanHiperbolica((Matrix<double>)I[ctr]));
                            //A{ nCamadasEscondidas + 1} = A{ nCamadasEscondidas + 1} + (obj.taxaDeAprendizado) * G{ nCamadasEscondidas + 1} *Y{ nCamadasEscondidas}';
                            var Ytr = (Matrix<double>)Y[ctr - 1];
                            accumulator[ctr] = (Matrix<double>)accumulator[ctr] + taxaAprendizado * (Matrix<double>)gradient[ctr] * Ytr.Transpose();
                        }
                        else if (ctr == 0)
                        {
                            gradient[ctr] = Matrix<double>.op_DotMultiply((Matrix<double>)adqMatrixTranspose((Matrix<double>)weigth[ctr + 1]), (Matrix<double>)derTanHiperbolica((Matrix<double>)I[ctr]));
                            accumulator[ctr] = (Matrix<double>)accumulator[ctr] + taxaAprendizado * (Matrix<double>)gradient[ctr] * vetEntrada;
                        }
                        else
                        {
                            gradient[ctr] = Matrix<double>.op_DotMultiply((Matrix<double>)adqMatrixTranspose((Matrix<double>)weigth[ctr + 1]), (Matrix<double>)derTanHiperbolica((Matrix<double>)I[ctr]));
                            var Ytr = (Matrix<double>)Y[ctr - 1];
                            accumulator[ctr] = (Matrix<double>)accumulator[ctr] + taxaAprendizado * (Matrix<double>)gradient[ctr] * Ytr.Transpose();
                        }
                    }
                }

                //Ajuste dos pesos
                for (int ctr = 0; ctr < camadas.Length + 1; ctr++)
                {
                    weigth[ctr] = (Matrix<double>)weigth[ctr] + (Matrix<double>)accumulator[ctr];
                }

                //FeedFoward
                for (int ctr = 0; ctr < camadas.Length + 1; ctr++)
                {
                    if (ctr == 0)
                    {
                        I[ctr] = (Matrix<double>)weigth[ctr] * vetEntrada;
                        Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));
                    }
                    else if (ctr == camadas.Length)
                    {
                        I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)I[ctr - 1];
                        Y[ctr] = Matrix<double>.Tanh((Matrix<double>)I[ctr]);
                    }
                    else
                    {
                        I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)I[ctr - 1];
                        Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));
                    }

                    //Calculo do erro quadrático
                    squareError += rowSquareSum(Matrix<double>.op_DotHat((vetorGabarito - (Matrix<double>)Y[ctr]), 2)) / 2;
                }

            }
            while (eqm[1] - eqm[0] > precisao && epocas < 1000);

            eqm[1] = meanSquareError(squareError, nAmostras);

            epocas++;


            object derTanHiperbolica(Matrix<double> matrix)
            {
                Matrix<double> matrixAux = Matrix<double>.Build.Dense(matrix.RowCount, matrix.ColumnCount);
                for (var line = 0; line < matrix.RowCount; line++)
                {
                    for (var column = 0; column < matrix.ColumnCount; column++) matrixAux[line, column] = 1 - Math.Pow(Math.Tanh(matrix[line, column]), 2);
                }

                return matrixAux;
            }

            object adqMatrixTranspose(Matrix<double> matrix)
            {
                Matrix<double> matrixAux = Matrix<double>.Build.Dense(matrix.RowCount, matrix.ColumnCount - 1);
                for (var line = 0; line < matrix.RowCount; line++)
                {
                    for (var column = 1; column < matrix.ColumnCount; column++) matrixAux[line, column - 1] = matrix[line, column];
                }

                return matrixAux.Transpose();
            }
            double rowSquareSum(Matrix<double> matrix)
            {
                double sum = 0;
                for (var line = 0; line < matrix.RowCount; line++)
                {
                    for (var column = 0; column < matrix.ColumnCount; column++) sum += matrix[line, column];
                }
                return sum;
            }
            double meanSquareError(double error, double sampleNumber)
            {
                return error / sampleNumber;
            }

        }
    }
}
