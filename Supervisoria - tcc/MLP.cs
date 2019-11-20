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
{-1.78998055497,-0.763006666127255,-0.100077239409696,0.512326227469786,3.49799390651746,3.20028560936836,2.88441772109884},
{-0.70724089907763,0.0702781218680802,-0.602925908076416,0.858567275695997,0.608828998189626,0.117732793622165,0.688768243108954},
{0.144422549138108,-2.59524623812378,3.71771191575113,-1.4531257411025,-3.46339072655372,0.180086988894771,-0.963962868227728},
{1.49256294417292,-0.108155266738534,1.5275020520922,-1.79407062700093,-1.8428332596607,-1.02452201988682,-3.09542437476319},
{1.27292985224832,4.76406975242173,-1.82547779460271,-2.33012429863006,-0.124630982779017,-2.19892286797858,-4.03794467197801},
{1.25158260899256,1.9568831309898,-0.336895403256943,-1.44646356626408,-0.452627685588366,-1.37192971649123,-2.22317642363875},
{1.17623154748324,3.30826164040117,-1.81720306907937,-1.03024174479281,-0.78037210504355,-2.82584174600697,-2.34773265461122},
{-1.65451778217674,-2.09754258514352,1.72560702711989,-0.229194937867026,2.06125152452529,4.02706969881021,0.925837664812269},
{-0.479029257616291,-2.66993281205763,-0.829065072821252,3.23107042383921,-0.822549394716005,-0.778111369543066,2.28363919520569},
{0.561823763457967,1.02100040754837,-1.20411543415787,1.05407598174484,0.473652915665887,-2.20583844774646,0.141980330191953},
{-1.49076707467504,-1.80263945724552,2.84253425229576,-1.79658481577409,2.8183761506964,5.49728364468397,1.4586615920463},
{1.01068916924539,2.46101439410559,-0.341803752437494,-0.52404081969822,-0.658115311529964,-1.2175748427022,-2.07689275266673},
{1.03063157202187,-1.18346393390041,-0.888946524030057,2.65165900520082,-2.56403053174966,-1.914818642617,-0.833485379861188},
{0.897708549081735,0.255404733754948,1.16759366121252,-0.430312688693372,-0.875518684074857,-0.293160674080659,-1.41165979073136}};


        static double[,] M2 = new double[,] {
{-1.50043287892145,1.6465197335853,0.651275683402768,0.71287152593031,-0.968613199315297,-0.244622623311376,-0.666392989888696,-0.0379662228158438,0.852769047903381,-0.039076574771051,-0.859651489587712,0.660027651363963,-0.724600026998627,-1.36451953982234,-0.942255264464138},
{1.16346555637316,0.483663031065113,-0.0619260141451891,-2.20314084060488,-0.794087572059503,-0.217792957532939,-0.28614848905859,0.524839052469457,-1.27536061532489,0.240813528965942,1.51867564580731,-0.425963030559078,0.110825607118394,-0.309768434101986,-0.415213013841581},
{-0.0957058817164596,0.4870090803255,0.368481639852062,-0.0913459688246688,-0.494882905350499,-0.800178708302311,-0.248817401882073,-0.635039970852834,-0.56363274909602,0.376257578398651,0.635579923334479,-0.529197814376236,-0.288527013595453,0.307507505435252,0.0613467288611716},
{0.560775428071746,0.647421201451385,-0.27757185492563,-0.421800264291555,0.601602608523332,0.766918380879839,0.0703592442889313,0.118076833023324,-0.305429450842217,-1.01565355980851,-0.319954488788572,-0.455161644499196,0.00251126845111648,0.0269782478198709,-0.0717531897068092},
{-0.444802583875584,0.278749200887994,-0.449153225707474,0.792505496868096,0.483177327150556,0.335580736891499,0.304622154771684,0.513201258972169,0.787207626765252,-0.509420338358129,-0.47465804261259,0.166880564349246,-0.562572158394582,0.175941027075811,0.124343729565654},
{0.518910392365348,1.14704605704614,-0.0871973730485299,-1.09518602723566,-0.586478291153657,0.806291979903408,0.16440495196139,-0.649086050564038,0.920799779759487,-0.569718646772329,-0.980144341110228,1.71639595954911,-0.0630463732922947,-0.600155331045931,-0.0524424703311006},
{0.54830871293169,0.626865390826398,-0.65210245199437,-0.0364090873832797,0.28489032726606,0.783086278455694,0.686765231090486,0.0397665817864191,0.659068680689359,-1.69581830965447,-0.457307651586001,1.73326531271187,0.392280587708201,-1.2907143757741,0.583762513172188},
{0.176349427299357,-0.638147090015856,-0.0690304309881351,0.770064196595594,0.999982959692394,-0.567320178832539,-0.470111565883512,0.121546565133652,0.251143325110541,-0.12598601712282,-0.852703730571774,0.794137148136298,0.0726138533866494,0.409808687317557,0.364924500093735},
{0.494089735740066,-0.975818050462966,0.286517108083656,0.31206136204472,-0.296593573967204,0.532680346794331,0.13378541459306,0.327753577014651,-0.836704855187014,-0.113493295678161,0.280997703546949,-0.922131126466812,-0.138439418399875,0.116424993695174,0.195740692490199},
{0.685401159841647,0.928508869404868,0.701437914111602,-2.09273887918286,-1.01971854124356,0.566514481492976,0.171940342309294,0.49297490285959,0.228953866584032,-0.431632287605337,1.06533887327634,0.155527646047481,0.487776988204341,-0.854391081421139,-0.335232790407519},
{-1.16273359780403,1.13476263232476,0.19024473417411,-0.48355742564574,-1.00146046919504,-0.125623534316957,-0.369612152691963,0.155536685624945,-0.642354150244495,0.994346839371764,0.263869678772831,-0.914562237827302,-0.294860558732159,0.583180377923555,-1.0719680710219},
{0.227294015193036,0.378815527598243,-0.276726187473358,0.24222038370721,-0.368834793281758,-0.68535284501077,0.199565801945374,-0.81059822521941,-0.0354311523657811,0.812334483598054,0.216107399232355,0.245717028411329,-0.701830970517951,0.19482654193932,-0.0667832413560504},
{0.127847953388357,-0.998606342564162,-0.163985227441706,-1.00283199009639,0.330229395522296,2.57185788905888,1.45235672205894,1.7577929414851,-1.39728139441018,-1.48640734239666,0.881703993698337,-1.66895409340379,1.24604025175382,-0.453196462758504,-0.183930024090739},
{0.097151828920268,-0.625593405440573,-0.638707659468021,0.154098167369456,-0.282145489068212,-0.68488393772421,-0.0219300005607257,0.516233207009262,0.245329814514482,0.370887636297907,-0.350840334959336,0.0807781975341152,0.147301848166294,0.855803542139157,0.225257531148485}};

        static double[,] M3 = new double[,] {
{-0.199494778810991,-0.468484752546822,-0.240984184091058,0.582178032054205,-0.638327846136375,-0.432940686474166,-1.52132949201724,-1.44349527010938,-0.0524907964343886,-0.142598143206363,-0.346067707411449,1.48570372160873,-0.0469968035031306,0.195512752135386,0.421384688550372},
{0.241371440136997,-0.688028096001973,0.0615764706068632,0.127629462829272,-0.193434398758585,-0.341078150185967,0.182599393177068,0.0984672498718321,-0.990743743124159,-0.0797651959070428,0.492157226992475,-0.574307995123609,-0.532925947613258,0.124550295418201,-0.574656595513435},
{-0.179153942852784,-0.254852835982383,-0.572457113118486,-0.337775799668344,0.161192885339465,0.253119014074023,1.02308289014252,-0.171322750658004,0.636980232774575,-0.763773341385838,0.111575946938654,-0.404201082524128,0.151950688040962,-0.210312555655279,0.764297483146049},
{0.133715557512051,-0.115761730941928,-0.136834124137995,-0.388685139388367,1.09071240092514,-0.185117607352167,0.319960636709647,0.370808620984323,0.159655453067557,0.405057109502305,0.299843166860026,0.321879649819085,-0.541482920394292,1.07340068037656,-0.658312954225661},
{-0.402156019197158,0.870992519057704,-0.12365974056512,-0.743215187795433,0.432492116531375,-0.297601692595395,0.625996391027115,1.16893646952065,0.115128487706168,-0.219956564645802,0.221459613112692,-0.531240573482132,-0.844799701281518,0.023510076552416,-0.445092418156447},
{-0.189582755458385,0.96550450861973,-0.40008340251549,-0.336224214779569,-0.602932526613884,0.339910125239259,0.0464792204954394,0.268096562430175,0.311788764618226,-0.923701090396966,0.203667824463777,-0.171416685159636,-0.193629079075052,0.365456537833456,-0.357958472367147},
{-0.156657121251149,-0.485224530352206,0.221360156928981,-0.443392766788567,0.805463559313855,0.316165215093835,-0.370376165342765,-0.0854488575069002,0.186908890857744,0.280553141436503,-0.0744049603549246,0.119814405955104,-0.952658615040867,2.05382169417237,-0.454013959703795},
{-0.513333387411458,1.17955568622614,0.766035647950222,0.561543353920215,-0.109856983964418,-0.0566186006568389,0.906298611171347,-0.703726604746302,-0.596359377538022,0.322736175453338,1.55801920008924,1.85737113795128,0.110580659530144,0.584911867804312,-0.00279279334598798},
{0.345039702505542,-0.0854274442256598,-1.61281110156024,-0.382649835702697,0.125744243822857,0.944306313405209,-0.789609428445831,-0.274007793075691,0.800475160550669,-0.100162428242351,-0.832873533124313,-0.0343946716929243,0.462404774542319,0.336307254809371,0.548484527723035},
{-0.079057020028596,0.465859771560321,0.926521553125943,0.198245893628936,-0.112686741299622,-0.0191635862806956,0.915223790471703,0.400911183755203,0.94842643857828,0.789093844269941,-0.362133335175107,0.545544699542232,-0.296174379984309,0.069763669602476,0.831035161692442},
{0.5562469066362,-0.458245845464492,0.450777597779044,0.178929563863489,0.144676506030111,0.0631255179322857,-0.102392683097732,0.263464917512557,0.0258668879401394,-0.148279286423689,-0.45426201991537,-0.670221346604343,0.0558624053861154,0.749046415219202,0.146149203239286},
{0.0779525811921212,-0.871258067919005,0.378823955869056,0.260805852547681,-0.0887902727107458,-0.144846463042409,-0.974437804189142,-0.545973897949096,-0.974088727198235,-0.341883896071992,-0.235688308704016,0.344538555518978,-0.272119905869264,0.557490464209705,-0.512064942804885},
{0.310832599406137,0.929760592555827,0.209090256481629,0.729054923691278,0.643548888802672,-0.805542778466431,0.514342341361002,0.365080768843165,-0.00209016800201295,-0.467025476920245,0.903691624763952,0.103005811766433,0.400695072631115,-0.85978975287938,-0.175297414611757},
{0.0777285991467417,-0.731554091894037,-0.20467144729768,-0.66536621466679,-0.167711382021521,0.685709590649758,0.883931753915565,0.407171355815729,-0.686452012300084,0.0242529838307637,0.859064796111555,-0.313405946229595,-0.165615110324096,0.679050254527313,-0.102032665970237}};


        static double[,] M4 = new double[,] {

{0.142576545390807,-0.726812376626168,0.198721732390715,-0.0361712406510265,0.70769650323682,-0.397291446326208,0.300526714867318,0.0861387088898597,0.37688278305573,-0.0926895919038161,-0.444260879912416,0.329306419580534,-0.594734557601967,0.0407859446481402,0.378630525479707},
{-0.119528454629522,-0.0347001110612316,0.057445421712841,-0.0581761175480922,0.121025783085033,0.369927254440007,-0.470896362165287,-0.693695688443395,0.686800276343523,-0.603742253307515,-0.399941412325517,-0.593983094050492,0.424865679678807,0.358474274443169,-0.219318502329776},
{-0.104084302081096,-0.377882216529916,0.203230289270422,0.402359173158283,-1.0477625536085,0.15263325023714,0.747539444529993,-0.669017415597462,-0.415327990138729,0.0908383958610447,-0.790958570212632,-0.80402502816026,-0.240445594133246,0.119585695473523,-0.688449674301237},
{0.33855316465371,0.266872444410819,-0.619074402037661,0.530364882005866,0.761614521850496,-0.176668297503242,-0.187145180851642,0.876819654742489,-1.13360464778751,0.865816063670795,0.139099727443971,-0.218660948790543,-0.226741831586031,-0.91491767845809,0.296041599200783},
{-0.228304239509561,1.19191887550423,0.145972275824632,0.257828214444511,0.00189096112930043,-1.27891630706501,-0.182844179376763,-0.3626941761285,-0.247232602541568,0.38438507730694,-0.0126732363754749,-0.217220496934538,0.483803680724977,-0.218201335537904,-0.717862622202047},
{-0.281674622720092,0.60726433637115,-0.967933459506248,0.65538095945241,0.0113279478302184,-0.101721650744438,-0.177055771126803,-0.957967313027672,-0.12410029733692,0.490927131458938,0.553805908509803,-0.338172506000399,-0.363261578871965,-0.215037745231047,-0.518234609737405},
{0.354123664855066,0.473985621457465,-0.444302667331573,-0.179990217333419,-0.174500084165459,0.136458737569462,0.888192002163202,0.744081574272948,-0.642580837102707,0.558937392600987,0.341521571193193,0.507730743209484,0.285389398434641,-1.18892308438879,-0.19715887064052},
{0.154843243930561,-0.0211552731542116,0.508826317230668,0.967019739582803,-0.751837380349151,0.0944063767368764,0.323954739226306,-0.651060538698534,-0.832555802943837,-0.414493569299085,0.260280624013455,-0.33996857812484,-0.852493314232651,0.605202630378427,0.350661367975079},
{0.479550172421195,-1.21003043394629,-0.434165755571963,-0.165804030945833,0.567564079143284,0.683021768918031,0.389486818717438,0.0831564165456766,-0.611382398226274,-0.211364331304668,0.59135031557964,-0.155809058933954,-0.56662399454622,0.461744103152168,-0.0922545990177886},
{0.533531086354425,0.186895487963805,0.120891898034057,-0.0761769996091029,-0.591899334115839,-0.203671672183985,0.9281920477591,-0.10883025590538,-1.10602949022246,0.770450219905623,-1.59783305595265,-0.105715111626342,1.12427244895341,0.0783921760068404,-0.248289650611168},
{-0.353589353346732,0.511044953180462,0.127539278142324,-0.190783983538924,-0.782258833494251,0.200438095565845,-0.0903668766054627,-0.44832798990707,-0.240297064600431,-0.251402103363512,-0.515334399449375,0.0533110958125624,-0.147616628308809,0.751175487912467,-1.05575470450355},
{-0.116454640601213,-0.317419949931449,0.349787914336591,0.438128573898881,-0.205953054042586,-0.743818711967264,0.505883919711761,0.97019486166263,0.206424273552851,-0.475741679202813,-0.133874127554049,0.462654252510215,-0.366947571717829,-0.444045624174566,0.740396288815524},
{-0.501139689062743,0.610301279800358,0.773256429727665,-0.135729857218351,0.154255618732056,-0.431012749709986,0.116617900947956,0.788723331961197,-0.384348815493446,0.303301078836042,0.357969373258498,0.00773642245774065,0.30901816543893,-0.497473117379876,-0.756399126635386},
{0.371818206461557,-0.229960010923299,-0.189346786657679,1.06257255413188,-0.182579819638783,0.24351116251493,0.728509649282468,-0.738977918190619,-0.447696597194961,-0.218055822947903,0.282040963234445,0.492192215184819,-1.00815901472914,-0.162963649387223,-0.524976698524737}};



        static double[,] M5 = new double[,] {
{-0.378116085980619,0.052156066235807,0.442318779051221,0.138557282407811,-1.1267721031526,-0.316274872914704,0.447488898971092,-0.0628554043478088,-0.19805924701839,0.183008857492876,-0.563706846768038,-0.0159141782423462,0.834097053708933,0.486137987999866,0.651888062808663},
{0.314818416836877,-0.0530869909002759,0.658877845774818,-0.249727043764916,-0.333197899056048,0.107475499276128,-0.898532274363023,-1.00596534603262,-0.217790126331338,-0.279439218773246,-0.574278932759873,-0.277310356470193,0.349257162460872,-0.284993179990906,-0.650337944826335},
{0.982475140073246,0.574375214896241,0.245794876807618,0.0359206767386994,-0.619291759888675,-0.881908187034689,0.196735044281754,-0.456307870251773,0.217698260119383,1.04672462260854,-0.375674831445507,-0.0595512616288019,-0.303740389308554,-1.13278053644976,0.342526799815943},
{0.700014712536784,0.581022575188987,-0.209695918626498,0.279095066302215,-0.155326975946386,-0.733962263303806,0.538425358132122,0.0898053313601922,0.669382253025572,0.281570732986234,-0.769093494017636,-0.540747543582592,0.0737538018136933,-0.813022422460396,0.877396240949096},
{0.377445146059392,-0.240802690004663,-0.257505507618324,-0.554854239436682,-0.0858895213949003,0.437443587484328,-0.805681423933397,0.338944813744633,-0.181693400323653,-0.00424912659023916,-0.418873263530713,0.590927156753561,-0.0778915834368955,0.577746121009614,-0.338238125750692},
{0.356959971837569,0.237717326252375,0.789106178176259,0.181112480422896,-0.769563330083934,-0.69860297803527,0.11952539801761,-1.11580588914784,0.445063178294728,0.244559054137311,0.301747668062956,0.427657017529568,0.315277503408247,-0.618064499672711,-0.40478275674628},
{0.432073657533844,-0.64998200113887,-0.699283892697067,0.750606277094655,0.996447301377707,0.576104959607904,-0.272804317611307,-0.712754864841083,0.961438939461808,0.0271961849337259,0.37144972615416,0.313235907492061,0.210205060492548,0.174929209258767,0.917638759412228},
{0.254110010737587,0.0609532979773776,0.373926750146429,-0.066905893815706,-0.137493311389343,-0.0861516277170697,-0.26565390103874,0.757009056609162,0.474083345012166,-0.221079869763075,-0.360045626925276,-0.1853593803236,0.574082627404028,0.00323121763481783,0.399844917592377},
{-1.04280618705873,-0.185704793940591,-0.082325041173474,0.739602742529075,-0.558666749597007,0.500021353900551,-0.286992739536342,-0.0945340659990396,0.941657233356483,0.438575056342755,0.416022315521781,0.571153350774779,-0.37676921767386,0.529136324166739,0.439695390342449},
{0.604702779635495,0.13589697549648,-0.0771695236112205,-0.187887898890312,-0.814320572492251,-1.42960173426824,-0.709514152342107,-0.385818436261949,0.0687191032573775,0.427073119847318,0.434834087909182,-0.119061583658746,-0.0331809576332992,-0.553773799707325,-0.555275258180657},
{0.0170976228822695,0.565835599756299,0.243355156096257,-0.643534198655168,0.200690214173518,-0.54301819971905,-0.408989186999738,-0.489660545123953,0.0232816724094669,0.403861998028622,0.203956885879889,-0.976536360490431,0.519441882375805,0.0950386810428627,0.171049433154439},
{0.015356137442539,0.177588144705542,-0.632651438951477,-0.827519607679616,0.647098154439344,-0.364365954909941,0.0635211725881381,0.201266289404851,-0.968242958896481,0.0428315218886117,0.120314409551875,-0.956094062696304,0.972374660707949,0.785784068424845,-0.545708267448934},
{-0.175654564264131,-0.671684086941034,-0.15677667197466,-0.0975876538655936,-0.247531196358806,0.333062166575341,0.898610416923153,0.935868623476778,-0.632336511326011,0.587115073892068,0.145798683774702,0.617314285817832,0.275775569558231,0.0047682627317701,0.103753634907572},
{-1.23375415956382,-0.402985060028577,0.127075976510757,0.0859585457613295,0.0127242220778136,-0.631466352704032,-0.832466134869769,-0.224247041921452,-0.293864856345402,1.33447017192836,1.46539366868285,0.471533974265862,-0.339894670797708,0.330480405081057,0.236852981430365}};

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
        static Matrix<double> M66 = Matrix<double>.Build.DenseOfArray(M6);
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
            weigth.Add(M66);
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
