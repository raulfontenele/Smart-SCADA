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

        private static int nAmostras = 4008;

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
{-0.346599168452929,0.153867610531517,0.764666711388097,-1.35514146884381,1.43301284488579,1.90437142279429,0.00694589950236774},
{0.0325831933728695,1.37279320347334,1.0976635990798,-1.40206380260965,0.862512780029489,0.460959294521892,-0.888999304868456},
{-1.29605112566112,-2.30829780200817,0.251865834001079,0.73152176128393,0.752173908453823,1.99258139434607,2.11177841198545},
{-0.0379605749532262,0.4192235762029,-1.09104442579584,0.974228967926148,0.103364687664662,-1.96885874454142,0.659746719696298},
{1.6033010636308,3.94179645395061,-1.63408098069678,-1.53989360558994,-0.498035582060669,-3.54384302375523,-3.28405813720951},
{0.132728943722058,0.369373631767834,0.0716779352728318,0.429481278069317,-1.01827520355207,0.273414633207916,-0.555632404219728},
{0.34164853123192,2.09094502605447,-1.32576893813133,-0.0536260776675982,0.0844310856772976,-1.74783154359325,-0.627005454393297},
{-1.11245980656592,-0.667531622132106,0.64812555994626,0.477654946654334,1.00846297580657,1.53099689234897,1.55515499760487},
{-0.0185949364371317,-1.61892076443689,1.86092548081107,-1.3751294474799,-1.25551755169219,2.1571916659121,-2.20126105105431},
{-0.565811043437086,1.13345602369351,-0.236059352207095,-1.1626508765688,1.7904260469577,0.773094947025527,0.159771719719332},
{-0.243544536131284,1.77267806640342,0.275609774267336,-1.55526037503411,1.56681416510231,0.559080904355688,-0.663044406283103},
{0.642852622854502,-0.69059496664997,0.263254348809645,-0.537794154164296,-0.91457978403704,-0.61898732109534,-0.0973772963301973},
{-0.697774820887661,-1.19608289441699,-0.450053757492681,2.23907754605007,0.00411535472045847,-0.879274572121937,1.32941660869662},
{-0.124920956031214,-0.229161569660317,-0.721775630356022,0.585466489433724,1.00383596761443,-0.621990955659502,0.0626375079425427}};


        static double[,] M2 = new double[,] {
{0.434591764955042,0.38071470721327,0.442835592476782,0.291304730347625,0.0149733841446311,-0.501137648779601,-0.645576449964233,0.196165734047122,0.355015189676431,-0.808315391553317,1.10922013801753,0.834398652310639,-0.346421814671146,-0.0741026850769777,0.689748579798671},
{-0.487976807705904,-0.652023400938214,-0.887610545255064,0.301375070001271,0.39622275233561,0.875072330699571,-0.202889348189838,0.108576147009823,-0.25536640060157,-0.657622609842295,-0.631732459544559,-1.01210731665923,-0.271989263646246,1.18370481653065,0.385572219965261},
{0.190788050327378,0.251770012232372,-0.492235774480643,-0.164084994083194,-0.618968342026592,-0.0681931922777423,0.00444654044059597,-0.135770790889905,-0.383462587987289,0.740858831462691,0.163565035296446,-0.02945442185387,0.0969148637661297,0.0338161715908339,-0.484395407067301},
{0.162069908358006,0.317017836473311,-0.0803682203974633,0.68983773548632,0.435669027124011,-0.322301668668398,-0.13134154221229,-0.0800926512797079,-0.154604795997221,-0.849994305928768,-0.112268544805963,0.0693123573239984,-0.176139492114094,-0.0556502356558109,0.389981841594052},
{-0.123782391711457,0.921255481513935,0.251326313211402,0.974109010661462,-0.78264031885074,-0.686737085587024,0.334551695768151,-0.865707325823608,0.978583583524957,0.363209061198051,0.667946727312195,0.29831503998312,-0.854380957591382,-0.503829627536029,0.0979536866395164},
{0.163076693242039,-0.0228430340021189,0.128827636409916,-0.89251133473418,-0.422278883133825,0.747614564011239,0.373690121545688,-0.510433627534616,-0.669896333474089,0.407083639467799,-0.960535205536849,-0.682168920905546,0.576235073307276,-0.599284652417829,-0.269344304032027},
{-0.338689737768143,-0.262724374936696,0.257002250248081,-1.12421236838707,0.354018655690005,2.05422528824418,0.205164077687251,0.969591881372926,-0.652227462421506,0.150190064996477,0.648533183109013,0.741062281248907,-0.293734336366954,-0.496053752197374,0.40357027136084},
{-0.306675309040622,-0.286898659974209,-0.694291258462587,0.546051661103507,0.630879798940295,-0.21363696296858,-0.0484509074938699,-0.301667015950132,-0.206455311322649,-0.556602507917684,0.161843495335558,0.154872237215328,-0.178013527359693,0.769697041017672,0.537113822679911},
{-0.000646648439876826,0.964766623772065,0.877327275127125,0.152152305043938,-0.983516042933825,0.205479328989681,-0.172529349166002,-0.00563300102281513,0.0867573727425815,0.330813794152347,0.497292374341751,0.991689741004946,-0.049199989495492,-0.760525149779995,-0.558732990857357},
{0.279584734002087,-0.00711330672419254,0.139214448365019,-0.273016469317269,-0.145467458058552,0.741715495846718,-0.0386576117388598,-0.28017053079918,-0.32345347716803,0.47973481934776,0.328644151040543,0.484519029273889,-0.392116861236529,-0.490382342270772,0.356209754820537},
{0.0341050602964432,0.00742384446561428,0.440428530185933,-0.035271686692224,0.97806209498515,-0.360619309064687,0.220940131485487,0.684148287666214,-0.0871642018411049,-1.24872255102149,0.198695947041496,0.427467040091453,-0.146689747933616,-0.0388723679371546,0.113184671938285},
{-0.0657199872417935,-0.551171414951994,-0.10410287791221,0.47518141640396,-0.481328828641757,-0.617350604690263,0.475617961352506,-0.648560785123556,-0.135899282028456,0.859189618363965,-0.329575560204698,0.06055341677026,0.0147341905424156,0.447973893467934,-0.0599192950394348},
{0.298720638431477,-0.25977924391987,0.153337096114809,-0.197418515065674,-0.00814439512398345,1.07360866929997,0.390020381751408,0.804462093206913,-0.236860642896319,-0.523341845127371,-0.419655911089016,0.421891332860006,-0.0566583492038433,-0.469895599451117,-0.599823478308989},
{-0.407062887375442,-0.227070668318225,0.618411445090947,0.271381346496365,-0.52505263409867,0.444277939189974,-0.369625390327131,-0.541835921988785,-0.458600081802973,1.15722764379114,-0.100313942863358,-0.0464275967057464,0.163344824763565,-0.269241951780729,0.0580331986655044}};

        static double[,] M3 = new double[,] {
{-0.928620863075788,-0.88680677282121,0.787928464478153,-0.379736507355452,-0.448859983462662,-1.18202340606677,0.288544139841358,0.507989187937058,0.424234570397281,-0.305370368717229,0.157339504238695,-0.584597466458947,-0.298551981614372,0.100664740220268,0.0682181970754892},
{-0.234462552365411,-0.0264366778661901,0.306535203083533,-0.373221846610494,0.0692495454496172,-0.620900607961905,0.62800369910425,1.06674143408327,-0.410657391600267,0.0262091460320565,0.323815106919662,0.203216251596561,-0.394917649845806,0.688741991928027,0.308277494848514},
{-0.423034135145043,-0.792933554658663,0.317328620129631,0.589849354238134,-0.648364503994908,0.405573982576433,0.717085255204866,0.0839609851206732,-0.690179798959257,0.359283204842925,0.48331408591042,-0.754272606121012,0.678420719311136,-0.225548865307797,0.904162050378884},
{-0.119252234930848,-0.740823677447696,0.400739195776646,0.46066131657505,0.0707537554304854,0.383710782855757,0.25421331712568,-0.0593271230806406,0.281230154767394,-0.240589253936562,-0.550134478025996,-0.546654108511343,0.596161293790389,-0.349201208422637,0.369159894067899},
{0.188279314312433,0.250096223508875,0.58443077992683,-0.342118450240371,0.761072834765024,-0.186664561117354,0.0335828011642658,-0.449469286420236,0.00959467722044254,-0.450502565506512,-0.0196429455004824,-0.400696026432128,0.339920710787084,-0.264806232495686,0.259188883425742},
{0.319795187423743,1.14535835991297,-1.02046802739737,0.163304559432577,0.119478321145134,0.241218735430011,-0.502941629344935,0.0983848868916053,-0.585965222406945,1.5001112953766,0.737130989721208,0.142042761282981,0.116993728329648,0.0302283530580604,0.450905245830474},
{0.105668973727641,-0.351891696945969,0.558491397702642,-0.459074845723456,0.192372908632465,-1.09379319697831,-0.199297282572953,0.523501680011297,0.147676654057208,-0.0295672423350829,-0.238559108030032,0.901797086218459,-0.640106300979746,0.509198935782522,0.10514171937239},
{0.0827148642496397,-0.596523904103828,-0.330548521121806,-0.511300706024709,-0.041439033292503,0.199506480922722,-0.469233315733439,-0.827391987787525,0.299335765495623,-0.364870385830232,-0.641241272143433,-0.137517686427587,0.445575265490354,-0.502623011279924,-0.517846762631782},
{0.00424623403927876,0.571383320111377,0.331608033627258,0.130940810112434,0.364057507066629,0.208618836625264,-0.56895627496715,-0.543151469798316,0.679543019277892,0.240141076485167,-0.0498114607772832,-0.395477694610013,0.388262989489912,0.269490714341799,0.340514075513551},
{0.113563732149955,0.0605566929288107,0.537274459875534,0.0690541635050765,-0.0484478905916076,0.327848984549724,0.0255051081099216,0.123935758323353,-0.293341955732538,-0.22319226699617,-0.201972695623483,-0.497968759327071,0.150986883838189,-0.59614036901054,-0.151344774789016},
{-0.0264843603503094,0.86530155755653,0.317020597129681,-0.454088942890741,0.332486967928124,-0.185519335927472,-0.953609184087061,0.231720489084656,0.724446590314891,0.0561290812977805,-0.293056395615226,0.966206906744053,-0.434029963680682,-0.0568028435275249,-0.304217891226598},
{-0.000394107767816649,-0.356264626734548,-0.582696548224603,0.0943968658407564,0.383841080557792,0.366661927351269,-0.264317240057172,-1.11144143402644,0.655135511286282,-0.0637561632961407,-0.445599801273072,-0.374707173040851,0.673566703226117,-0.600735854039346,-0.194519153746601},
{-0.320541257914484,0.589165331124421,-0.676579184007699,0.267572545025368,0.396442762412219,0.509320705267084,-0.205796235336601,-0.0302294755213055,-0.373003261436803,0.593336209480238,0.280352718028594,-0.323272686959844,-0.519802914326055,-0.416508675948964,0.526101441112411},
{0.516356147792212,-0.436837654486875,-0.111553295478522,0.0988689317190045,-0.563329175684677,0.153495331370516,-0.405791335558477,0.452692997879604,-0.0267148133447241,0.163467599935809,-0.106727604529103,-0.30913683619416,0.841134098669248,-0.77475138888241,0.283190142190086}};



        static double[,] M4 = new double[,] {
{-0.0619192283115849,-0.506690513065521,0.0183731270448964,-0.0425707726550758,-0.479877252380032,-0.50403983716429,1.01787277102781,0.083369704504922,-0.273438249472198,0.455708129897371,-0.731024629427438,-0.473212649731987,0.227555701887509,0.840673204749698,-0.215513686606451},
{-0.721344847905491,0.351467606594086,0.844508089742843,0.546194673285133,-0.00548967486402972,-0.295264013439836,0.057838996511651,-0.094428442759487,-0.545147250463629,-0.409712003496713,-0.353645827906477,-0.625617327298938,-0.128393489856207,-0.369403625298219,-0.00790307359738962},
{-0.509945634865581,0.0875273435723831,-0.435187056193463,0.0398340125465148,0.0176268908957383,-0.218424706034411,-0.00586534941572495,0.057728567015663,0.449448067191273,0.169272948943248,-0.19627871139553,-0.186795699392005,-0.320347289541507,-0.0277787471223956,-0.653297716156935},
{-0.336226711439421,-0.75296023886499,0.983737711834996,-0.44256073793069,-0.453328767449166,-0.0195300630574609,0.458499603381672,0.546685054231031,-0.0799490157582329,-0.264539766185868,-0.411933226131068,-0.347158876090811,-1.02302720667969,-0.19591896803197,-0.15140850606437},
{-0.227735285526599,0.590457347241275,0.604828842562738,0.139025565239408,0.456832119477561,-0.0143161220508262,0.355349022892731,-0.0675986864231198,-0.4830930426458,-0.615700555519789,0.0842279701398454,0.422623651151071,-0.606363164353418,-0.320661336860321,-0.312298853507449},
{-0.140716388468348,1.11545097525589,0.427368183133788,-0.556031401124417,-0.335494009346435,0.363150463220842,-0.581601562150419,1.01650152027652,0.179327054090871,-0.073139185568926,-0.382137921240151,0.436689181058107,-0.299096761772837,-0.558986070359456,-0.78785236965239},
{0.634828364918901,0.278505351287388,-0.220143206444947,-0.857480258005866,-0.524950984745855,-0.312609983076516,0.83105813435126,-0.485332164119152,-0.231017475840329,0.153956820824695,-0.248335066412891,1.30229965887162,-0.336710780752933,-0.486028429409849,0.272519616836952},
{-0.806376550977335,0.119435279854549,0.321083546809725,0.152251243210899,0.779709453981816,0.165900017638904,-0.76159181672043,-0.631567410648902,0.162833003260765,-0.467659868282983,-0.187795225137705,-0.069485340357868,0.039900154608507,-0.863030344767828,0.401996530977564},
{-0.0981919654178591,1.04396150436033,-0.0369074110528084,-0.120696473652749,0.420875400528912,-0.269235625410722,-0.40870142978524,0.927026319217751,-0.721887939589882,0.129415026922066,0.54121305984098,-0.112042105132537,-0.589097977519716,0.0107193623668888,0.374402138613285},
{-0.198425304268824,0.421712296318132,-0.344105865808931,-0.138505873171781,0.421037353644063,0.592579147480866,-0.776325133845208,0.00857624464923308,0.0898114322255857,-0.0773869250304382,0.0105369525387566,0.140434231868516,0.0337086706685298,-0.841671904498238,-0.409404777977191},
{0.221383345658323,-0.195371020190003,-0.040559383471033,-1.27897362053338,-0.0806742489567583,-0.23670532952314,0.558786312458954,-0.291139324028905,0.390651866402023,-0.0974164322049321,-0.0170135645089284,0.694043626059795,-0.219645886447189,-0.469492142810586,-0.64321299514294},
{-0.168169473752832,-0.107011244618042,-0.0694458335287227,0.244636250459213,0.271489400540882,-0.118763090360236,-0.492875763715824,-0.132206687266017,-0.272398520251603,0.306983807003826,0.327952159746162,-0.365007039583411,0.111436643809768,0.310855346920548,0.747352256611242},
{-0.41801373250152,-0.114139686397789,-0.069331413027031,-0.27997874910232,0.788183326978183,0.67702174881934,-0.906163849006158,-0.399901477593054,0.85019100994402,0.763924327170163,0.0803563702080169,0.240107984020217,0.175638331314953,-0.184285043273626,-0.393206338180147},
{-0.352456020341688,0.0544289832292216,-0.148382050065035,-0.276602519822724,-0.587585309453081,-0.515735099748523,0.047001821234092,0.0374820972873387,0.43381582792815,0.0586776477314008,-0.22856801510811,0.23743040604408,0.463118660865923,-0.303029359210422,-0.584534878287044}};


        static double[,] M5 = new double[,] {
{-0.927051823730046,0.406594800889385,-0.778332548611578,0.13922890796957,-1.06852868782727,-0.403480560860115,-1.04909892747122,-0.617770391572762,-0.346896360698618,-0.989981570893938,0.269623787844933,-0.10421982804328,-0.359996399052661,0.485773018548775,0.625102145461213},
{0.0799926332705653,-0.0725701960414467,-1.11784281459981,-0.376275061015618,1.04012231649424,0.727867674743731,1.21074014765747,-0.726292177468772,0.96564354549989,0.807555149391833,-0.0493222405128852,0.116155099401702,0.215884509398923,-0.472111662657267,0.226560091206048},
{-0.957098899427393,-0.127722675009315,0.0328996879045264,0.538130616232884,0.375725624559453,-0.0637931479936774,-0.0586582985946151,-1.51366787690003,0.359973745553321,0.0117028834812529,-0.225762973614722,-0.653204763312521,0.0234010322530319,1.46438199641626,-0.423532831311383},
{0.569269821739265,0.210839620103227,-0.761203343534242,0.263462201738589,0.45606399409053,-0.0665891275975103,0.39752086759355,0.863388990891152,-0.00585074549965972,-0.165522783903941,-0.138878099468304,1.27385162447268,-0.758948453433205,0.423937037753705,0.711852238472758},
{-0.746980208135033,-0.953925948070163,0.637063550492377,0.431407420677337,0.148257033757879,0.341793034556134,-0.880170374596102,-0.758055806866279,1.41222742970046,-0.864880252714519,1.06154288051063,-0.193028510200312,0.351410841365112,-0.1773421791436,0.195110711821429},
{-0.856255163251487,-1.10996677983141,0.0555985185922329,0.261467559696808,0.0646276464078399,-0.00595501162110407,0.85849753941787,-0.669107697673112,-0.515199247802282,0.771844112981473,1.00703625202445,-0.163156211803756,-0.885078016511336,0.631568437462939,0.670402733359979}};

        static double[,] M6 = new double[,] {
{-0.606989924501233,0.341283593109123,-0.495253815677574,0.162344879401176,0.577571065694283,0.209335659922961,-0.104732701259513,0.200408362544778,-0.341121286095139,1.60099597721328,0.43297569716847,-0.654812128238052,-1.5437145705888,-0.926735978097412,0.0680674027238742},
{0.516506235871426,0.532406988606713,-0.618369247355063,-1.01122804219308,0.328583147364287,0.805865474185339,-0.863898005587687,-2.06653586332589,0.0449242256527264,-0.022689295744556,-0.416610042162007,0.694201329471622,0.732137035021178,0.860822537646645,-1.57475758023846},
{-1.19492984202978,0.0129900683832126,-1.10599484567826,-0.630640864259182,0.0387328253730185,-0.0215546833566497,-0.76440479198728,-0.187027524697935,0.151041920797306,0.833079280713466,-0.531968022470321,-0.794418437289579,-0.507749224098549,1.34866447597703,1.37761694875954},
{0.859948259063016,0.72651433427012,1.33896576703621,-1.511627961102,0.357580809066962,0.960513350972448,0.115588229160547,0.60618024600038,0.884724422234973,-0.333290457847113,0.315343060192468,0.0844338139393985,-0.989165569560601,-0.228641861328554,-1.15907057575121},
{-1.07279886707593,0.492993911403934,0.32333550898725,0.0218292893380363,1.34645751712231,0.376555605131598,-2.05314681778414,0.409191807483423,0.0945179078533706,0.18757925281018,-2.36250715093944,-0.27709072677621,0.249224125140626,0.126421724952502,-1.25880788898015},
{0.139887373558085,-1.09596044025134,0.177337529099821,-1.31165976981564,-1.30401610648141,1.05132784373883,-1.22697563638556,-0.194777887294441,-0.220865470863787,-0.155968045830139,0.0201066727843604,-0.353304863896202,-0.0891136006642564,-0.928011170212738,-1.12783722631873}};

        static double[,] M7 = new double[,] {
{-1.03441020845505,0.912014904142624,-0.771001604187895,2.03490878144954,-0.102524805251394,1.77150389922169,-1.50347063483358},
{-0.222567048641182,-1.98275031903635,1.61477567050225,-0.890373587494476,-2.14146968354077,-1.09598953982466,2.1514037903708},
{-1.57248741374994,2.09528592899821,1.14882084523438,0.884873130613159,2.58440454611616,-0.0460141699908716,0.723605535415205},
{0.958636399428587,0.0750815381393122,0.962078840325042,-1.03874087831256,-2.75439231704072,0.639434024978881,-0.759873223185485},
{-1.79334159060644,0.092582330946259,-0.844098208250097,1.45154839294305,0.338613468271202,-0.348422903904431,3.07107764806312},
{-0.0145028094270781,0.203521765481828,2.42699822665412,-0.111524353600014,-0.452482655655307,-0.431563835959646,0.0994763684856601}};

        //Deixar em 9 caso use bit de controle
        static Matrix<double> xTrainAux = Matrix<double>.Build.Dense(nAmostras, 6);
        static Matrix<double> dTrain = Matrix<double>.Build.Dense(nAmostras, 6);

        static Matrix<double> M11 = Matrix<double>.Build.DenseOfArray(M1);
        static Matrix<double> M22 = Matrix<double>.Build.DenseOfArray(M2);
        static Matrix<double> M33 = Matrix<double>.Build.DenseOfArray(M3);
        static Matrix<double> M44 = Matrix<double>.Build.DenseOfArray(M4);
        static Matrix<double> M55 = Matrix<double>.Build.DenseOfArray(M5);
        //static Matrix<double> M66 = Matrix<double>.Build.DenseOfArray(M6);
        //static Matrix<double> M77 = Matrix<double>.Build.DenseOfArray(M7);
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
            //weigth.Add(M66);
            //weigth.Add(M77);

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
