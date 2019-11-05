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
using System.IO;

namespace Supervisoria___tcc
{

    class MLP
    {
        private int epocas = 0;

        private static int nAmostras = 3790;

        private double precisaoRequerida;

        private double taxaAprendizado = 0.1;

        private int[] camadas;

        private int qtdEntrada = 6;

        double[] eqm = new double[] { 0, 1.0000001 };

        double squareError = 0;

        int tamanhoSaida;

        private int qtdMaxEpocas;

        public static string pasta_dados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bancos de dados\";
        public static string base_dados = pasta_dados + "DadosScada.sdf" + ";password = 'password123'";
        public static string nome_usuario = "Raull";

        //Criando arrayList
        private static ArrayList I = new ArrayList();
        private static ArrayList weigth = new ArrayList();
        private static ArrayList Y = new ArrayList();
        private static ArrayList gradient = new ArrayList();
        private static ArrayList accumulator = new ArrayList();

        Matrix<double> vetEntrada = Matrix<double>.Build.Dense(1, 6);
        Matrix<double> vetorGabarito = Matrix<double>.Build.Dense(1, 6);

        //Mudar para 9 caso bit de controle seja utilizado
        private static double[] maiorValorEntrada = new double[6];
        private static double[] menorValorEntrada = new double[6];


        static double[,] M1 = new double[,] {
{-0.620595115930497,-3.27512599533323,4.63122063416219,-3.14109159841443,-1.61063990874149,1.80338842149259,-2.4200327427595,-0.304036498297212,-0.417550291215049,-0.590511486295111},
{1.10040173266905,3.70265242356439,-4.169898420982,2.44073499722448,-5.55051932065711,-7.07537829078947,-1.91681327869825,0.299541831513943,0.234631794506335,0.680149428755404},
{2.32700288835677,9.15319221092669,-3.24031897701683,-3.54282162446069,-3.24354638089205,-7.48571106932552,-6.06950761213476,0.725832596472372,1.01247442299334,0.941795719939175},
{-0.0052273590245378,-2.12241820102442,-3.64256002868376,5.68904980440882,-3.01060885567361,-3.34465621379048,-1.09718272892547,0.0293996777703531,0.429586475560672,0.390363888176749},
{0.570559963086548,3.76322080539846,0.452124935922359,-3.75539028582496,1.41849192539185,-0.194864703214676,-1.92485307689548,0.230874095885792,0.43063322355099,0.707951990020744},
{-1.32194160623523,0.692081498208678,-1.82066012024691,1.31150200312916,4.35686386400426,0.628404813727147,3.96145529900462,-0.442492347924053,-0.382473378662024,-0.905336207242155}};

        static double[,] M2 = new double[,] {
{0.476187811716066,-0.0421901386068083,1.49618239398483,0.273736681701644,1.77320474459082,-1.84382696064071,-0.487546861160311},
{0.237090191565117,-1.61399147976638,2.43578571880011,1.39905403697069,1.10186225735673,0.0532989205438798,1.82005273323146},
{1.18932900872155,0.241022282006313,0.939760208726923,0.00819914420403561,-1.24278022667785,1.21300350784923,-2.15361458080643},
{-0.926714796836497,-1.0192491325081,2.44550807821022,-0.862814553202243,2.52219096180049,-2.42974345955902,-0.451879404284725},
{-0.0910867755747517,-0.707046605901879,1.93594483577006,3.58082355094264,-0.525966952267814,2.00951446255842,-1.04200516594132},
{-0.39193915385253,3.19684593077193,-0.670160892104313,-0.156288138624782,-0.805830456920556,0.24688276075197,-2.0846916926683}};

        static double[,] M3 = new double[,] {


{-0.363983777800184,0.167866446659991,1.01622659953856,-1.25992723153976,0.639225771115159,0.779022732333925,-0.0135710952527906},
{-0.0499554270382057,-1.73645148265308,-2.00970691794014,-1.36952760912838,1.2274445203173,-1.41971124956872,-0.625167017031208},
{-0.572099369171471,-0.710837528164676,-0.510119575100945,1.18756119188332,-1.88986495774434,-0.105882501615906,-0.44768091374873},
{-0.0512354703542668,0.120317856086198,-0.329272801568833,0.691776312636124,0.125416457859161,1.09001646374852,2.23646005015631},
{1.28899430086196,-1.19446213950691,-0.96528552250093,-1.40935963593721,-0.736687263781651,-0.636474205575278,-0.700159985255136},
{-0.509067618585987,2.4587793983946,-2.48746616028014,-0.470414427449609,-0.322683264799353,-0.134639241503966,0.230098256660365}};


        static double[,] M4 = new double[,] {
{0.946830033792851,0.940434186489644,-0.190092258201193,-0.535700760544841,-2.46930098118335,-0.917719312814735,-1.25983012810676},
{0.871195485655908,0.723636485391868,-0.608413639448324,1.66390837004443,-0.402045787219286,0.784864316849073,-1.33652817546906},
{-0.474704775782365,-0.555489795091491,-1.80763295813315,0.702860968946031,0.0921530154956209,-0.571774020550177,-0.596246642398566},
{-1.1338626875926,0.26227536596125,2.54079120564334,-0.323906287500786,-0.929761792007377,0.56682106008475,2.55554093190398},
{-0.321951119994184,-0.502325179196168,-0.534159022398068,-0.625744514046586,2.21272008278338,-0.556504854555937,1.68977576351514},
{-1.00964615016677,1.0649428050189,0.7699839556961,-1.04264945459467,0.0367400299894931,-0.996493646430713,-1.48203800079498}};
        static double[,] M5 = new double[,] {

{-0.232971903371579,0.142823263749787,0.981033549538562,-1.66407359108375,1.92141490735358,0.23621950660912,-0.591015787966414},
{-1.4875600659786,2.69672258106325,-1.15275736386496,1.39334078269244,-1.84858273019097,0.81192055916064,0.526166513408146},
{-1.78835722722016,-2.06369673678788,-1.58500414839525,-0.13162966552252,2.80053248364672,2.16299124041499,0.435379913950733},
{0.418140901204429,1.72195526250209,0.899290420053485,0.68936608798013,0.163781379526967,-2.63471959036084,0.732669285366364},
{-1.51428903419034,1.46219255357768,-3.15349569406903,0.404443825289617,1.42685471382521,0.850440653738868,-0.574853800514402},
{-0.473542959232741,0.239245067074874,0.634148691346226,0.510545489808069,0.195736452206837,0.013735606550683,2.89663721425152}};

        //Deixar em 9 caso use bit de controle
        static Matrix<double> xTrainAux = Matrix<double>.Build.Dense(nAmostras, 6);
        static Matrix<double> dTrain = Matrix<double>.Build.Dense(nAmostras, 6);

        static Matrix<double> M11 = Matrix<double>.Build.DenseOfArray(M1);
        static Matrix<double> M22 = Matrix<double>.Build.DenseOfArray(M2);
        static Matrix<double> M33 = Matrix<double>.Build.DenseOfArray(M3);
        static Matrix<double> M44 = Matrix<double>.Build.DenseOfArray(M4);
        static Matrix<double> M55 = Matrix<double>.Build.DenseOfArray(M5);

        public MLP(double taxa, double precisao, int[] conf, int saida, int maxEpocas)
        {
            precisaoRequerida = precisao;
            taxaAprendizado = taxa;
            camadas = conf;
            qtdMaxEpocas = maxEpocas;
            tamanhoSaida = saida;

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
            //weigth.Add(w1);
            

            //Criando matrizes intermediárias
            for (var index = 1; index < camadas.Length; index++)
            {
                Matrix<double> w2 = Matrix<double>.Build.Dense(camadas[index], camadas[index - 1] + 1);
                accumulator.Add(w2);
                for (var line = 0; line < w2.RowCount; line++)
                {
                    for (var col = 0; col < w2.ColumnCount; col++) w2[line, col] = rand.NextDouble() - 0.5;
                }

                //weigth.Add(w2);
            }

            //Criando ultima matriz de pesos
            Matrix<double> w3 = Matrix<double>.Build.Dense(tamanhoSaida, camadas[camadas.Length - 1] + 1);
            accumulator.Add(w3);

            for (var line = 0; line < w3.RowCount; line++)
            {
                for (var col = 0; col < w3.ColumnCount; col++) w3[line, col] = rand.NextDouble() - 0.5;
            }

            //weigth.Add(w3);



            //Matrizes de pesos
            weigth.Add(M11);
            weigth.Add(M22);
            weigth.Add(M33);
            weigth.Add(M44);
            weigth.Add(M55);


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

            gravarMatrizPesos();

            return eqm[1];

        }

        public object aplicacao(double[] vetorEntrada)
        {
            Matrix<double> xTestAux = Matrix<double>.Build.Dense(1, vetorEntrada.Length,vetorEntrada);
            findMaxMinValues(xTrainAux);
            Matrix<double> xTest = (Matrix<double>)preparacaoMatrizEntradaAplicacao(xTestAux);
            //Console.WriteLine("Xteste:" + xTestAux);

            //Para todas as amostras
            for (var amostra = 1; amostra <= xTestAux.RowCount; amostra++)
            {
                //vetEntrada = (Matrix<double>)lerLinhaBancoDados(amostra - 1);

                vetEntrada = (Matrix<double>)preencherVetor(xTest, amostra - 1);
                // vetorGabarito = (Matrix<double>)preencherVetor(dTestAux, amostra - 1);
                //Console.WriteLine("VetorEntrada:" + vetEntrada);

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
                else if(maiorValorEntrada[column] == menorValorEntrada[column] && maiorValorEntrada[column] == 1)
                {
                    matrix[0, column] = 0.5;
                }
                else if (maiorValorEntrada[column] == menorValorEntrada[column] && maiorValorEntrada[column] == -1)
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
                for (var j = 1; j < 13; j++)
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

        private void gravarMatrizPesos()
        {
            if (!File.Exists(@"C:\Users\RAULFINHO\Documents\Bancos de dados\text.txt"))
            {
                FileStream criador = File.Create(@"C:\Users\RAULFINHO\Documents\Bancos de dados\text.txt");
                criador.Close();
            }
            else
            {
                //Abrir arquivo no modo escrita e adicionar o horário
                StreamWriter arq = new StreamWriter(@"C:\Users\RAULFINHO\Documents\Bancos de dados\text.txt");
                for(var ctr = 0; ctr<camadas.Length ;ctr++)
                {
                    arq.WriteLine(weigth[ctr]);
                    arq.WriteLine("===================");

                }
                arq.Close();
            }
        }

        private void findMaxMinValues(Matrix<double> matrix)
        {
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
            }

        }
    }


}
