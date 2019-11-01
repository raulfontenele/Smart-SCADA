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

        private static int nAmostras = 7664;

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

        static double[,] M1 = new double[,] {
{-0.289272019037653,-0.00570637245973971,0.831475433563106,0.105495514611021,0.195698413502288,-1.42416092906644,-2.15650807138179,3.33648435031814,0.683736597559179,1.45783202876926   },
{0.526847053894631,0.10020856442665,-0.169981415744127,-0.358443416637773,1.6585220488241,2.03196898851705,-1.11429770085035,-0.287245317488442,-1.32707413611017,0.108828176932989      },
{0.0103072229870185,0.355301463371143,-0.234945153766428,0.119736948266827,-0.818510575008081,-4.82114899221303,-0.868642508807877,3.68705508453337,1.62588683820998,3.18308482241111    },
{0.172916010952012,-0.119776354069698,0.176003400475738,-0.0996116584919262,1.1782226646478,-2.55952622198604,-0.212047457833282,0.213431989586344,-0.641618986706418,1.2213248120071    },
{-0.581156162433818,0.0448779046464844,-0.0638199242408719,0.0790369526571539,-3.30293872011075,0.228519671970951,-1.65603002879678,2.95175363069044,2.40913047850302,0.726869970865375  },
{-0.123289974052177,0.0691055245125474,-0.0694691269944498,-0.314700408608956,1.98156905375707,1.66158505496151,2.99273777410179,-3.53242472905167,-3.80567065220531,-1.07513845077523   },
{-0.00975721525268542,-0.183174279441812,-0.11458844028734,-0.118087266464898,1.33733938108161,0.58505172645875,0.437691858869965,-1.38325245673195,-0.826221822401209,-0.452276814630276},
{-0.162685543447308,-0.00270600718190248,0.108080530975144,0.217282502933164,-2.52951179237088,-0.536048354184164,-0.835116525151151,1.9034103549881,0.996639121073693,0.978110477606919 },
{-0.231951693573346,-0.304038603851887,-0.278181918480815,0.106111718470915,0.214215794664394,-0.972651285521259,-1.2536394008326,1.44484057575364,-0.73742704761196,1.06790570007231    },
{-0.40030441748435,0.582802446800078,-0.288213814773345,0.677409791207019,-5.06952224226832,-0.73385833142515,-1.80220573008837,2.39581437319654,3.30383783937285,3.31248996639535       },
{0.277324670074716,-0.0463789409231127,-0.140785869834175,0.317825974486892,-0.33527948963793,1.01868107610196,-2.79785115302105,0.884115379390762,0.881009489859574,0.449017834304667   },
{ 0.273531827732093,0.0125448337142355,0.0263448009649289,0.226491044034317,2.89884853380551,0.500312948935084,0.343560244077113,0.131774065846036,-1.83766076381751,-2.3383978846927 } };

        static double[,] M2 = new double[,] {
{0.88610209079915,-0.518422095429356,0.514204723241475,-0.771490245141707,-1.05681193829175,1.26938408480605,-0.535142832294122,-0.527723130230443,0.251103157661391,-0.570211075196547,0.970862130398784,0.640788210654849,-0.839058279901627      },
{-0.122444576424593,0.099948254180589,0.728406008771719,0.773524114254428,-0.10202140376006,-0.510526823461088,0.680890816761662,-0.181587949666546,-0.291900446426486,0.16420428735583,-0.1852814363464,0.120801206350181,0.478961545999091        },
{-1.11286311186082,-1.11775287343436,1.51410190119033,-2.12027455908463,-0.273991072933416,0.314364558081543,-0.304374441648791,0.304907329377977,-0.0684928126763807,-0.132146932821222,0.394975826386036,1.14848631872276,0.0852582500589982      },
{0.105258813084316,-0.184716465193963,1.41073424264532,0.233812716123179,1.09502305922335,-0.0774635586699468,0.897924815130021,0.215482568413586,-0.771192284044022,-0.200902779788278,-2.41124169560884,0.741933525420535,1.32700807053241        },
{0.832362555882652,-0.407626033540768,-0.837712623770707,-0.600134248262238,0.481380036524887,-0.682541721786673,1.52484880659127,-0.27050798624924,0.338845158555455,-0.472157696874571,0.168368641142757,-1.06728460045726,-0.805084187325065     },
{0.0902821644088191,-1.06596664798463,-0.382677620331372,-0.911967902020062,-0.707877453805637,-0.0934954413818344,1.18345763832617,0.203155610011755,-0.28142939349218,-0.723126110144345,-0.784779811351298,-0.363840171415273,0.219984825369948  },
{-0.223672286388865,-0.0540858323966829,-0.755307012803012,0.816727132317187,0.0689127081641175,0.781842347470469,-1.47075003224304,-0.0527301006261726,-0.0572849455706358,-0.344886378015518,1.28398360501659,-0.026507513271541,-0.3620659208337 },
{-0.498699286284641,-1.58548080670334,-1.50609785086273,-1.15009400135265,-1.38662175203086,-0.125131753259601,0.830222202795858,-0.248400227721338,0.568396137133627,-0.933831821289039,-0.0579333236680024,-1.15764469485178,-0.68464368118624    },
{-0.549130927490131,0.41364380855583,0.389523265883366,-0.544705700003928,-1.34757446997116,1.12010570872555,-0.285187981040776,0.302662742103813,0.0976126368737748,-0.0483490750391891,-0.572621560285158,0.951722684821295,0.413158896892011     },
{-0.613825037915279,-0.194420708430313,0.402169627808534,-0.604248086413743,0.940860241656399,-1.06207401053933,0.276224616713328,0.600790425217027,-0.837147192499615,0.304279102386264,0.112049026316782,0.905574745435356,-0.927347031108823     },
{-0.771778572355223,0.709273402863765,-0.221238818828628,-0.44517466515737,0.957988451652982,-1.26240128833853,1.00987383887673,0.315753274941924,-0.865729869412818,0.177182547826916,-0.632251962786446,-0.823669155871091,-0.412676527410465     },
{ 0.318101421251347,-0.699550872543817,0.124865999913161,0.227444943287065,0.2069028012519,-0.939520096527698,0.544944582631375,0.145457833686588,0.564555141439561,-0.0890814567086588,0.83610657240514,-0.148912853567675,-0.994191046822934 } };

        static double[,] M3 = new double[,] {
{0.557760306998556,-0.00729458754651476,0.104021243181137,0.121112543735649,-0.49408258537845,0.632549496251389,0.0320311227123563,0.245255306091276,-0.174541283696506,-0.0168093296423367,0.39610357012068,0.636271950122826,0.596625833184436     },
{-0.369973960705047,-0.831538968184929,-0.307732535681412,1.0262521125016,-0.746063249645068,-0.434769026720321,-0.843975262886733,0.549604990806636,-0.725107107391504,0.0268913861791087,1.24455716938463,-0.226200531124957,0.730503198310666     },
{-0.290257062726506,0.271845760761639,0.689452152382998,-0.0724544907426385,0.119566785596736,-0.576209660830253,-0.418240601864471,-0.104758153153786,-0.914045613608209,-0.424828371245446,0.588842669822645,-0.564222732684989,-0.736380575154212 },
{0.187817076406264,-0.275344465179906,-0.709770524775688,-0.986101451533921,0.590394180662241,1.12402803693881,0.884115204553866,0.113777961558378,1.4431464826101,-0.235992492413398,-0.339080496053417,0.556391773879352,0.571968016644544         },
{0.542461018968905,-0.504688546134174,-0.153714650504257,0.00912551885247919,-0.375104777051359,0.667533774525054,0.250197706588624,-0.0155366403445368,0.119852154098638,-1.01549067243492,0.548510491662306,-0.0348876706287179,-0.140931406699796 },
{-0.602234667802571,0.94150060481813,-0.356737440027938,1.25772446183014,-0.42487835178934,-0.569333490992061,0.54041555084804,-0.729661742159051,0.955803760122115,1.35705398870452,-0.473111964311239,0.818886663431507,-0.693721735891657         },
{0.870102945635166,0.21104967965114,-0.473068390930443,-0.655264989791221,-0.688747678804101,-0.748753554057586,-1.33169237688644,1.13584036656505,-0.151335302880983,0.152675903355728,-1.49526485301167,-0.524630442794471,-0.873168856712195      },
{-0.705936143581227,-0.423052853151314,0.325744501820438,0.790257123534059,-0.403043221916859,-0.537170273139736,0.554595657687316,-0.492279781225729,0.0819439155258382,1.14923259333534,-0.0355360875095394,-0.516491771932488,-0.327403913576197  },
{-0.532832452064363,-0.348855366904437,0.539893126243108,-0.543121284523701,-0.431953717914449,-1.01012363962787,0.38967332498889,-0.132157396310876,0.289335063972645,0.0732304288466171,-0.561585883756956,-0.472753820127352,-1.27826028299223    },
{0.600705455978549,-0.145882361456097,-0.258398861121957,-0.322920313754489,1.31885141804211,-0.211269793387939,0.017572005815308,0.273608892259786,-0.787087408715661,-0.359929891359562,0.679403605232373,0.760261279875794,0.654658718051936      },
{0.561932977159134,1.20876040435407,-0.329688682303789,0.978793496792366,-1.11240785508454,0.305825348000491,-0.268902524128686,0.248240203824947,-0.040665881342213,-0.409964200240914,0.466043047777929,-0.406593217545196,0.938669977634223       },
{ 0.730970328459057,0.989398185897574,-0.582659442866542,0.0716138025906127,0.273888054113996,-0.00144460098450559,0.767426826584588,-0.720048838547298,-0.635187181877456,0.754407523457017,-1.05363745131904,-1.18420619975526,-0.565878569971577   }};


        static double[,] M4 = new double[,] {
{-0.393723062717648,-0.32695730422294,-0.173384730631083,0.311820166427987,-0.0748989139835657,-0.465706259536695,-0.334570480718545,-0.565510113857933,-0.584239164617085,1.42085133578715,0.245955312748001,-0.915118214533038,-0.497205265293718   },
{0.0364974728475508,0.28250566459415,-0.0364688977091643,-0.509249831081859,-0.690596718035577,-0.247762540922669,0.669247254689811,-1.07460389259886,0.11355117970676,-0.13362272940262,-0.0969293374621026,0.0854469960297972,0.434323806055354     },
{-0.377301187580186,0.67332240611196,0.457152934793951,-0.0654146681410027,-0.366054853631288,0.572454343003375,0.450587034663401,-0.127921957448724,-0.0695473125647562,0.0833073395211965,0.975007005584318,0.124315107346145,-1.28498250823828     },
{0.345128023463528,-0.669453720003085,-1.26124222525918,0.429140275229402,0.384763018783511,0.213553096007914,-0.120681213577419,0.251902422998797,-0.266896306905232,1.08808385400543,-0.167193486335966,0.198946262929068,0.917725791623348         },
{0.195936253212505,0.151496928002841,1.12980896128498,0.00382209718175704,-0.861560997035831,0.384363953804623,-0.848464746289756,0.912952559342845,-1.3317943690336,-0.0538665868334714,0.409239746331232,0.872005977602979,0.575582105560471        },
{-0.364810386312736,-0.119760111403961,0.373279459927858,-0.127186458734552,-0.593017416696583,-0.656071167868415,0.712971293033622,0.483360868561958,1.05187492876317,-0.0547168252893515,0.342262276151123,-0.341019958902498,0.505627779325944     },
{-0.434965715214516,0.0907125688216131,0.94879609666585,-0.626832912973918,0.393451744478992,-0.684792194441784,0.29669571243109,-0.364940788145732,-0.0386395385420973,-0.140272155085502,-0.125155935675106,0.181513031251228,-0.171946290782819    },
{-0.481547434018291,0.320994371354816,-0.534062828934766,0.211353045372566,0.113462567855144,-0.181778392957621,0.876412177773389,-0.539506859220434,0.87748713635597,0.339816455684429,-1.62099787839834,-0.510002437780387,0.301197284752221        },
{0.777916030087317,0.26011643829825,0.746280457493751,0.488001311039924,-0.902749513474363,-0.441298837376904,0.530900573943079,-0.282032334028689,0.17538931778237,-0.482056461364942,1.2844372806383,0.122456688583073,-0.723357117709198           },
{0.745773797324076,0.23772817719467,-0.550776715596953,0.839048408530095,-0.243513063247137,0.132846646150772,0.0234562240052528,0.806140299657358,-0.250160296044801,0.706273205962675,0.895478945601899,-0.135189698050134,0.609487958856856        },
{0.044652493190957,0.301572993671466,-0.250826713521779,-0.852961195638669,1.57229142878987,0.668877197923911,0.0967775855457076,-0.883900582294602,-0.56657586127012,-0.706656610638167,0.205108365263514,-0.693546966396786,0.341510232907313       },
{ 0.180194339255272,-0.731829037372025,-0.640905225542799,-0.16380191553221,-0.0507973815361882,-0.354213098617002,0.385030102937996,-0.837095996154779,-0.512952438509258,0.857919910089107,0.942873393652028,-0.497037895097258,-0.850869536122775 } };

        static double[,] M5 = new double[,] {
{0.368511770641629,-1.10032086561289,0.197003218151634,-0.136499340452546,0.161772880915548,1.21978981341358,-0.410511696724545,0.101496363800537,0.0710175312405402,-0.791509584888779,0.182246435034102,0.892007971082944,-1.73682877512661   },
{-0.501813584971113,1.45829233874203,-0.103197269960708,1.79074358129655,0.279289772376095,-1.13544053761824,-1.34307433061194,0.431119388586272,0.607888502535964,-0.143084435010631,-0.919050754199734,-0.460738876932248,0.985937033776433   },
{-0.368701813016751,0.458679736874196,0.976454117566527,-0.834698359167971,-1.12631264139423,-0.61077802739856,0.614694149358385,0.549240130820886,-0.122874104394702,-0.184578969439767,-1.65372902861096,0.358461828804266,-0.315050672237442 },
{0.792458901446746,0.446263276636136,-0.875233310403446,0.863749800603873,-0.176897932998299,1.01671044763242,-0.741014796508922,-0.624800196831793,-2.10561924350901,0.0917271009578739,0.33382027540042,0.76799027903999,-0.304489567451998   },
{-0.619238352917547,0.0352795986372199,-0.218865488151817,-0.877735494997136,0.251364857925556,-1.08013569531845,-0.856451125382606,0.355838101832227,0.253742084288466,-1.93359332756199,-0.848552755217563,1.10902091893283,-0.463421210686727},
{ -1.23881393311549,0.55969583910507,-0.0241375617805665,1.10821124587692,-1.61284670063906,-1.19684882046834,0.263210957988733,0.631622331418814,-0.179328966394903,1.19089967180672,0.0931757545105002,1.80734611800083,0.395713857529385 } };

        static Matrix<double> xTrainAux = Matrix<double>.Build.Dense(nAmostras, 9);
        static Matrix<double> dTrain = Matrix<double>.Build.Dense(nAmostras, 6);

        static Matrix<double> M11 = Matrix<double>.Build.DenseOfArray(M1);
        static Matrix<double> M22 = Matrix<double>.Build.DenseOfArray(M2);
        static Matrix<double> M33 = Matrix<double>.Build.DenseOfArray(M3);
        static Matrix<double> M44 = Matrix<double>.Build.DenseOfArray(M4);
        static Matrix<double> M55 = Matrix<double>.Build.DenseOfArray(M5);

        //static Matrix<double> xTrainAux;
        // static Matrix<double> dTrain;

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
            //Console.WriteLine("Xteste:" + xTest);
            //var cont = 0;

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
