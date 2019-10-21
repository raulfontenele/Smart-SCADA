using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using System.Collections;
using System.Data.SqlServerCe;
//using System.Windows.Forms;
using System.Data;
//using Supervisoria___tcc;

namespace Supervisoria___tcc
{

    class MLP
    {
        private int epocas = 0;

        private static int nAmostras = 3014;

        private double precisaoRequerida;

        private double taxaAprendizado = 0.1;

        private int[] camadas;

        private int qtdEntrada=9;

        double[] eqm = new double[] { 0, 1.0000001 };

        double squareError = 0;

        int tamanhoSaida;

        private int qtdMaxEpocas;

        //Criando arrayList
        private static ArrayList I = new ArrayList();
        private static ArrayList weigth = new ArrayList();
        private static ArrayList Y = new ArrayList();
        private static ArrayList gradient = new ArrayList();
        private static ArrayList accumulator = new ArrayList();

        Matrix<double> vetEntrada = Matrix<double>.Build.Dense(1, 2);
        Matrix<double> vetorGabarito = Matrix<double>.Build.Dense(1, 2);

        private static double[] maiorValorEntrada = new double[9];
        private static double[] menorValorEntrada = new double[9];


        static double[,] array2DTeste = new double[,]
        {
            {8.30,18.75 },
            {16.15,23.85},
            {26.35,28.5 },
            {20.5,7     },
            {21,22.15   },
            {4.35,20.25 },
            {8.15,10.35 },
            {17.2,19.9  },
            {17.3,3.25  },
            {23.9,7.65  },
            {24.5,7.75  },
            {20,22.95   },
            {3.05,14.15 },
            {3.95,19.55 },
            {12.8,18.05 },
            {27.2,4.55  },
            {9.30,20.3  },
            {21.45,21.95},
            {27.75,27.35},
            {8.90,9.05  },
            {14.85,19.55},
            {13.55,18.85},
            {11.85,16.5 },
            {27.35,18.45},
            {24.3,24.85 },
            {23.2,18.25 },
            {8.05,18.15 },
            {13.8,19.05 },
            {22.05,26.5 },
            {5.15,21.8  },
            {11.6,15.25 },
            {19.35,31.65},
            {18.75,7.10 },
            {12.7,5.20  },
            {26.2,22.3  },
            {3.35,11.4  },
            {19.9,6.95  },
            {12.55,17.85},
            {20.7,22.55 },
            {24.9,29.65 },
            {25.65,23.45},
            {31.45,16.55},
            {11.55,14.35},
            {16.2,19.9  },
            {22.75,11.4 },
            {19.6,23.15 },
            {15.55,27.75},
            {21.85,3.05 },
            {26.3,14.45 },
            {27.35,19.1 },
            {22.3,11.3  },
            {22.9,19.65 },
            {12.65,10.9 },
            {22.25,21   },
            {13.25,10.1 },
            {11.65,15.7 },
            {15.8,13.5  },
            {18.2,19.55 },
            {15.8,8.05  },
            {11.8,16.05 },
            {24.8,12.7  },
            {17.85,11.5 },
            {26.05,23   },
            {19.55,11   },
            {30.3,13    },
            {15.7,3.70  },
            {22.5,7.30  },
            {23.6,3.30  },
            {21.45,11.05},
            {9.35,8.35  },
            {14,23.55   },
            {3.45,17.75 },
            {16.4,27.75 },
            {7.30,14.35 },
            {20.35,31.45},
            {23.35,25.65},
            {9.70,7.85  },
            { 23.8,25.3 },
        };

        static double[,] array2DdTeste = {{1,1},
                                        {1,1},
                                        {-1,1},
                                        {-1,1},
                                        {1,1},
                                        {1,-1},
                                        {1,1},
                                        {-1,1},
                                        {1,1},
                                        {-1,1},
                                        {-1,1},
                                        {1,1},
                                        {1,-1},
                                        {1,-1},
                                        {-1,1},
                                        {1,1},
                                        {1,1},
                                        {1,1},
                                        {-1,1},
                                        {1,1},
                                        {-1,1},
                                        {-1,1},
                                        {-1,1},
                                        {1,-1},
                                        {1,-1},
                                        {1,1},
                                        {1,1},
                                        {-1,1},
                                        {1,-1},
                                        {1,-1},
                                        {-1,1},
                                        {-1,1},
                                        {-1,1},
                                        {1,1},
                                        {1,-1},
                                        {1,-1},
                                        {-1,1},
                                        {-1,1},
                                        {1,1},
                                        {-1,1},
                                        {1,-1},
                                        {-1,1},
                                        {-1,1},
                                        {-1,1},
                                        {1,-1},
                                        {1,1},
                                        {1,-1},
                                        {1,1},
                                        {1,-1},
                                        {1,-1},
                                        {1,-1},
                                        {1,1},
                                        {-1,1},
                                        {1,1},
                                        {-1,1},
                                        {-1,1},
                                        {1,-1},
                                        {-1,1},
                                        {-1,1},
                                        {-1,1},
                                        {1,-1},
                                        {1,-1},
                                        {1,-1},
                                        {1,-1},
                                        {-1,1},
                                        {1,1},
                                        {-1,1},
                                        {1,1},
                                        {1,-1},
                                        {1,1},
                                        {1,1},
                                        {1,-1},
                                        {1,-1},
                                        {1,1},
                                        {-1,1},
                                        {1,-1},
                                        {1,1},
                                        {1,-1}};

        Matrix<double> xTestAux = Matrix<double>.Build.DenseOfArray(array2DTeste);
        Matrix<double> dTestAux = Matrix<double>.Build.DenseOfArray(array2DdTeste);

        static Matrix<double> xTrainAux = Matrix<double>.Build.Dense(nAmostras, 9);
        static Matrix<double> dTrain = Matrix<double>.Build.Dense(nAmostras, 6);

        public MLP(double taxa, double precisao, int[] conf, int saida, int maxEpocas)
        {
            precisaoRequerida = precisao;
            taxaAprendizado = taxa;
            camadas = conf;
            qtdMaxEpocas = maxEpocas;
            tamanhoSaida = saida;
            //qtdEntrada = nEntrada;

            inicializacaoMatrizes();
            lerBancoDados();

        }

        private void inicializacaoMatrizes()
        {
            //Inicializando a variável randômica
            Random rand = new Random();

            //Criando matrizes de pesos

            //Criando primeira matriz de pesos
            Matrix<double> w1 = Matrix<double>.Build.Dense(camadas[0], qtdEntrada + 1);
            accumulator.Add(w1);

            for (var line = 0; line < w1.RowCount; line++)
            {
                for (var col = 0; col < w1.ColumnCount; col++) w1[line, col] = rand.NextDouble() - 0.5;
            }
            //Matrix<double> w11 = Matrix<double>.Build.Dense(camadas[0], qtdEntrada + 1);
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
            Matrix<double> w3 = Matrix<double>.Build.Dense(tamanhoSaida, camadas[camadas.Length - 1] + 1);
            accumulator.Add(w3);

            for (var line = 0; line < w3.RowCount; line++)
            {
                for (var col = 0; col < w3.ColumnCount; col++) w3[line, col] = rand.NextDouble() - 0.5;
            }

            weigth.Add(w3);

            //Criando as matrizes de I , Y e Gradient
            for (var index = 0; index < camadas.Length; index++)
            {
                Matrix<double> In = Matrix<double>.Build.Dense(camadas[index], 1);
                Matrix<double> Yn = Matrix<double>.Build.Dense(camadas[index] + 1, 1);
                I.Add(In);
                gradient.Add(In);
                Y.Add(Yn);
            }
            Matrix<double> Isai = Matrix<double>.Build.Dense(tamanhoSaida, 1);
            Matrix<double> Ysai = Matrix<double>.Build.Dense(tamanhoSaida, 1);
            I.Add(Isai);
            gradient.Add(Isai);
            Y.Add(Ysai);
        }

        public double treinamento()
        {
            Matrix<double> xTrain = Matrix<double>.Build.Dense(xTrainAux.RowCount, xTrainAux.ColumnCount + 1);
            xTrain = (Matrix<double>)preparacaoMatrizEntrada(xTrainAux);

            do
            {
                //Zerar o acumulador
                for (int ctr = 0; ctr < camadas.Length + 1; ctr++)
                {
                    Matrix<double> aux = (Matrix<double>)accumulator[ctr];
                    accumulator[ctr] = Matrix<double>.Build.Dense(aux.RowCount, aux.ColumnCount);
                }

                eqm[0] = eqm[1];

                //Para todas as amostras
                for (var amostra = 1; amostra <= nAmostras; amostra++)
                {
                    //vetEntrada = (Matrix<double>)lerLinhaBancoDados(amostra - 1);

                    vetEntrada = (Matrix<double>)preencherVetor(xTrain, amostra - 1);
                    vetorGabarito = (Matrix<double>)preencherVetor(dTrain, amostra - 1);

                    //FeedFoward
                    for (int ctr = 0; ctr < camadas.Length + 1; ctr++)
                    {
                        if (ctr == 0)
                        {
                            I[ctr] = (Matrix<double>)weigth[ctr] * vetEntrada.Transpose();
                            Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));
                        }
                        else if (ctr == camadas.Length)
                        {
                            I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)Y[ctr - 1];
                            Y[ctr] = Matrix<double>.Tanh((Matrix<double>)I[ctr]);
                        }
                        else
                        {
                            I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)Y[ctr - 1];
                            Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));
                        }
                    }

                    //Backward
                    for (int ctr = camadas.Length; ctr >= 0; ctr--)
                    {
                        if (ctr == camadas.Length)
                        {
                            gradient[ctr] = Matrix<double>.op_DotMultiply(vetorGabarito.Transpose() - (Matrix<double>)Y[ctr], (Matrix<double>)derTanHiperbolica((Matrix<double>)I[ctr]));
                            //Console.WriteLine((Matrix<double>)gradient[ctr]);
                            var Ytr = (Matrix<double>)Y[ctr - 1];
                            accumulator[ctr] = (Matrix<double>)accumulator[ctr] + taxaAprendizado * (Matrix<double>)gradient[ctr] * Ytr.Transpose();

                        }
                        else if (ctr == 0)
                        {
                            gradient[ctr] = Matrix<double>.op_DotMultiply((Matrix<double>)adqMatrixTranspose((Matrix<double>)weigth[ctr + 1]) * (Matrix<double>)gradient[ctr + 1], (Matrix<double>)derTanHiperbolica((Matrix<double>)I[ctr]));
                            accumulator[ctr] = (Matrix<double>)accumulator[ctr] + taxaAprendizado * (Matrix<double>)gradient[ctr] * vetEntrada;
                        }
                        else
                        {
                            gradient[ctr] = Matrix<double>.op_DotMultiply((Matrix<double>)adqMatrixTranspose((Matrix<double>)weigth[ctr + 1]) * (Matrix<double>)gradient[ctr + 1], (Matrix<double>)derTanHiperbolica((Matrix<double>)I[ctr]));
                            var Ytr = (Matrix<double>)Y[ctr - 1];
                            accumulator[ctr] = (Matrix<double>)accumulator[ctr] + taxaAprendizado * (Matrix<double>)gradient[ctr] * Ytr.Transpose();
                        }
                    }
                }

                //Ajuste dos pesos
                for (int ctr = 0; ctr < camadas.Length + 1; ctr++)
                {
                    //Console.WriteLine((Matrix<double>)accumulator[ctr]);
                    weigth[ctr] = (Matrix<double>)weigth[ctr] + (Matrix<double>)accumulator[ctr] / nAmostras;
                }

                //FeedFoward Final
                //Para todas as amostras
                for (var amostra = 1; amostra <= nAmostras; amostra++)
                {
                    vetEntrada = (Matrix<double>)preencherVetor(xTrain, amostra - 1);
                    vetorGabarito = (Matrix<double>)preencherVetor(dTrain, amostra - 1);

                    for (int ctr = 0; ctr < camadas.Length + 1; ctr++)
                    {
                        if (ctr == 0)
                        {
                            I[ctr] = (Matrix<double>)weigth[ctr] * vetEntrada.Transpose();
                            Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));

                        }
                        else if (ctr == camadas.Length)
                        {
                            I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)Y[ctr - 1];
                            Y[ctr] = Matrix<double>.Tanh((Matrix<double>)I[ctr]);
                        }
                        else
                        {
                            I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)Y[ctr - 1];
                            Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));
                        }

                    }

                    squareError += rowSquareSum(Matrix<double>.op_DotHat((vetorGabarito.Transpose() - (Matrix<double>)Y[camadas.Length]), 2));
                }


                eqm[1] = meanSquareError(squareError, nAmostras);
                Console.WriteLine(eqm[1]);
                squareError = 0;
                epocas++;

                Console.WriteLine("Terminou a epoca " + epocas);

            } while (Math.Abs(eqm[1] - eqm[0]) > precisaoRequerida && epocas < qtdMaxEpocas);

            return eqm[1];

        }

        public object aplicacao(double[] vetorEntrada)
        {
            Matrix<double> xTestAux = Matrix<double>.Build.Dense(1, vetorEntrada.Length,vetorEntrada);
            Matrix<double> xTest = (Matrix<double>)preparacaoMatrizEntradaAplicacao(xTestAux);
            var cont = 0;

            //Para todas as amostras
            for (var amostra = 1; amostra <= xTestAux.RowCount; amostra++)
            {
                //vetEntrada = (Matrix<double>)lerLinhaBancoDados(amostra - 1);

                vetEntrada = (Matrix<double>)preencherVetor(xTest, amostra - 1);
                // vetorGabarito = (Matrix<double>)preencherVetor(dTestAux, amostra - 1);
                //Console.WriteLine(vetEntrada);

                //FeedFoward
                for (int ctr = 0; ctr < camadas.Length + 1; ctr++)
                {
                    if (ctr == 0)
                    {
                        I[ctr] = (Matrix<double>)weigth[ctr] * vetEntrada.Transpose();
                        Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));
                    }
                    else if (ctr == camadas.Length)
                    {
                        I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)Y[ctr - 1];
                        Y[ctr] = Matrix<double>.Tanh((Matrix<double>)I[ctr]);
                    }
                    else
                    {
                        I[ctr] = (Matrix<double>)weigth[ctr] * (Matrix<double>)Y[ctr - 1];
                        Y[ctr] = Matrix<double>.Build.DenseIdentity(1).Multiply(-1).Stack(Matrix<double>.Tanh((Matrix<double>)I[ctr]));
                    }
                }

                //Realizar a probabilidade
                Y[camadas.Length] = (Matrix<double>)realizeProbability((Matrix<double>)Y[camadas.Length]);
                /*
                if (verificarAcerto((Matrix<double>)Y[camadas.Length], vetorGabarito) == true)
                {
                    Console.WriteLine("Entrou");
                    cont++;
                }
                Console.WriteLine("Terminou a amostra " + amostra + " do teste");
                */
            }
            //Console.WriteLine("A taxa de acerto foi de " + cont);
            return Y[camadas.Length];

        }

        private object realizeProbability(Matrix<double> matrix)
        {
            for (var index = 0; index < matrix.RowCount; index++)
            {
                if (matrix[index, 0] >= 0)
                {
                    matrix[index, 0] = 1;
                }
                else
                {
                    matrix[index, 0] = -1;
                }
            }

            return matrix;
        }

        private bool verificarAcerto(Matrix<double> matrixResp, Matrix<double> matrixGab)
        {

            for (var index = 0; index < matrixResp.RowCount; index++)
            {
                if (matrixResp[index, 0] != matrixGab[0, index])
                {
                    return false;
                }
            }

            return true;
        }

        private object lerLinhaBancoDados(int id)
        {
            // Variáveis
            double[] vetorEntrada = new double[qtdEntrada];

            //Estabelecendo ligação
            SqlCeConnection ligacao = new SqlCeConnection(@"Data Source = " + Auxiliar.base_dados);
            ligacao.Open();

            //Retirar dados da base de dados
            SqlCeDataAdapter adaptador = new SqlCeDataAdapter("SELECT * FROM TabelaControle" + Auxiliar.nome_usuario, ligacao);
            DataTable dados = new DataTable();

            adaptador.Fill(dados);

            for (var i = 0; i < qtdEntrada; i++)
            {
                vetorEntrada[i] = Convert.ToDouble(dados.Rows[0][i]);
            }

            Matrix<double> vetEntrada = Matrix<double>.Build.Dense(1, qtdEntrada, vetorEntrada);

            //Desligando todas as ligações
            adaptador.Dispose();
            ligacao.Dispose();

            //Retorno
            return vetEntrada;
        }

        private object preencherVetor(Matrix<double> matrix, int amostra)
        {
            Matrix<double> matrixAux = Matrix<double>.Build.Dense(1, matrix.ColumnCount);
            for (var i = 0; i < matrix.ColumnCount; i++)
            {
                matrixAux[0, i] = matrix[amostra, i];
            }

            return matrixAux;
        }

        private object normalizacaoMaxMin(Matrix<double> matrix)
        {

            Matrix<double> matrixAux = Matrix<double>.Build.Dense(matrix.RowCount, matrix.ColumnCount);

            //Encontrar o maior e o menor valor da coluna
            for (var column = 0; column < matrix.ColumnCount; column++)
            {
                double maior = matrix[0, column];
                double menor = matrix[0, column];

                for (var line = 0; line < matrix.RowCount; line++)
                {

                    if (matrix[line, column] > maior) maior = matrix[line, column];
                    else if (matrix[line, column] < menor) menor = matrix[line, column];
                }

                maiorValorEntrada[column] = maior;
                menorValorEntrada[column] = menor;

                //Normalizar
                for (var line = 0; line < matrix.RowCount; line++)
                {
                    if (maior == menor && maior == 1)
                    {
                        matrixAux[line, column] = 0.5;
                    }
                    else if (maior == menor && maior == 0)
                    {
                        matrixAux[line, column] = -0.5;
                    }
                    else
                    {
                        matrixAux[line, column] = (matrix[line, column] - menor) / (maior - menor) - 0.5;
                    }

                }
            }
            return matrixAux;
        }

        //Funções de auxílio
        private object derTanHiperbolica(Matrix<double> matrix)
        {
            Matrix<double> matrixAux = Matrix<double>.Build.Dense(matrix.RowCount, matrix.ColumnCount);
            for (var line = 0; line < matrix.RowCount; line++)
            {
                for (var column = 0; column < matrix.ColumnCount; column++) matrixAux[line, column] = 1 - Math.Pow(Math.Tanh(matrix[line, column]), 2);
            }

            return matrixAux;
        }

        private object adqMatrixTranspose(Matrix<double> matrix)
        {
            Matrix<double> matrixAux = Matrix<double>.Build.Dense(matrix.RowCount, matrix.ColumnCount - 1);
            for (var line = 0; line < matrix.RowCount; line++)
            {
                for (var column = 1; column < matrix.ColumnCount; column++) matrixAux[line, column - 1] = matrix[line, column];
            }

            return matrixAux.Transpose();
        }
        private double rowSquareSum(Matrix<double> matrix)
        {
            double sum = 0;
            for (var line = 0; line < matrix.RowCount; line++)
            {
                for (var column = 0; column < matrix.ColumnCount; column++) sum += matrix[line, column];
            }
            return sum / 2;
        }
        private double meanSquareError(double error, double sampleNumber)
        {
            return error / sampleNumber;
        }
        private object adicionarMenosUm(Matrix<double> matrix)
        {
            Matrix<double> auxMatrix = Matrix<double>.Build.Dense(matrix.RowCount, matrix.ColumnCount + 1);
            for (var line = 0; line < auxMatrix.RowCount; line++)
            {
                for (var column = 0; column < auxMatrix.ColumnCount; column++)
                {
                    if (column == 0) auxMatrix[line, column] = -1;
                    else auxMatrix[line, column] = matrix[line, column - 1];
                }
            }
            return auxMatrix;
        }

        private object preparacaoMatrizEntrada(Matrix<double> matrix)
        {
            return adicionarMenosUm((Matrix<double>)normalizacaoMaxMin(matrix));
        }

        private object preparacaoMatrizEntradaAplicacao(Matrix<double> matrix)
        {
            return adicionarMenosUm((Matrix<double>)NormalizacaoMinMaxAplicacao(matrix));
        }

        private object NormalizacaoMinMaxAplicacao(Matrix<double>matrix)
        {
            for (var column = 0; column < matrix.ColumnCount; column ++)
            {
                if(matrix[0, column] > maiorValorEntrada[column])
                {
                    matrix[0, column] = 0.5;
                }
                else if (matrix[0, column] < menorValorEntrada[column])
                {
                    matrix[0, column] = -0.5;
                }
                else
                {
                    matrix[0, column] = (matrix[0, column] - menorValorEntrada[column]) / (maiorValorEntrada[column] - menorValorEntrada[column]) - 0.5;
                }
            }

            return matrix;
        }

        private void lerBancoDados()
        {

            //Estabelecendo ligação
            SqlCeConnection ligacao = new SqlCeConnection(@"Data Source = " + Auxiliar.base_dados);
            ligacao.Open();

            //Retirar dados da base de dados
            SqlCeDataAdapter adaptador = new SqlCeDataAdapter("SELECT * FROM TabelaControle" + Auxiliar.nome_usuario, ligacao);
            DataTable dados = new DataTable();

            adaptador.Fill(dados);

            nAmostras = dados.Rows.Count;

            for (var i = 0; i < nAmostras; i++)
            {
                for (var j = 1; j < 16; j++)
                {
                    if (j <= 6)
                    {
                        dTrain[i, j - 1] = Convert.ToDouble(dados.Rows[i][j]);

                    }
                    else
                    {
                        xTrainAux[i, j - 7] = Convert.ToDouble(dados.Rows[i][j]);
                    }
                }

            }

            //Desligando todas as ligações
            adaptador.Dispose();
            ligacao.Dispose();

            //Retorno
            //    return vetEntrada;
        }


    }


}
