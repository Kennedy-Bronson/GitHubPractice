// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

//variables
string fileType = ""; // holds type of file
string qualityType = ""; // holds quality of file
double bitrate = 0; // holds bitrate
string monoStereo; //holds wav choice
int minutes = 0; //holds the minutes
int seconds = 0; //holds the seconds
double duration; //holds calculate duration
double subtotal; //subtotal
double costPerMin; //cost per minute
double costPerMB; //cost per mb
double fileSize; //calculated file size
double tax;
double total;
string output = ""; // output of file type + quality

//named constants
const double MP3STANDARD = 1.20;
const double MP3PREMIUM = 1.44;
const double MP3ULTRA = 2.40;
const double MONOSTANDARD = 5.29;
const double MONOPREMIUM = 8.64;
const double MONOULTRA = 17.28;
const double STEREOSTANDARD = 10.58;
const double STEREOPREMIUM = 17.28;
const double STEREOULTRA = 34.56;
const double SUBTOTAL_A = 1.99;
const double SUBTOTAL_B = 5.99;
const double SUBTOTAL_C = 9.99;
const double SUBTOTAL_D = 12.99;
const double TAXRATE = 0.0723;


//display menu
Console.WriteLine("Welcome to SmoothTunes!");
Console.WriteLine("Choose your file type: ");
Console.WriteLine("\t A - MPEG Layer 3 (MP3)");
Console.WriteLine("\t B - Waveform Audio File Format (WAV)");
Console.Write("\nEnter your choice of file type (A or B): ");
fileType = Console.ReadLine();

//validate file type input
if (fileType != "A" && fileType != "B" && fileType != "a" && fileType != "b")
{
    Console.WriteLine("\n ERROR: Invalid file type. Program will terminate.");
    Environment.Exit(0);
}

if (fileType == "A" || fileType == "a")
{
    //MP3; display mp3 menu
    //output string
    output += "File Type: MP3 \nFile Quality: ";

    Console.WriteLine("Choose your MP3 file quality:");
    Console.WriteLine("\t A - Standard Quality - 160kbps");
    Console.WriteLine("\t B - Premium Quality - 192kbps");
    Console.WriteLine("\t B - Ultra Quality - 320kbps");
    Console.Write("\nEnter your choice of file quality (A, B, or C): ");
    fileType = Console.ReadLine();

    //validate input of quality type
    if (qualityType != "A" && qualityType != "a" && qualityType != "B" && qualityType != "b" 
        && qualityType != "C" && qualityType != "c")
    {
        Console.WriteLine("\n ERROR: Invalidfile type. Program will terminate.");
        Environment.Exit(0);
    }

    if (qualityType == "A" || qualityType == "a")
    {
        //standard mp3
        bitrate = MP3STANDARD;
        output += "Standard - 160kbps";
    }
    else if (qualityType == "B" || qualityType == "b")
    {
        //premium mp3
        bitrate = MP3PREMIUM;
        output += "Premium - 192kbps";
    }
    else
    {
        //ultra mp3
        bitrate = MP3ULTRA;
        output += "Ultra - 320kbps";
    }
}
else
{
    // WAV file
    ///start output string
    output += "File Type: WAV";

    //display mono/stereo menu + input
    Console.WriteLine("Choose your sound type: ");
    Console.WriteLine("\t A - Mono");
    Console.WriteLine("\t B - Stereo");
    Console.Write("\nEnter your choice of sound type (A or B): ");
    monoStereo = Console.ReadLine();

    //validate sound type input
    if (monoStereo != "A" && monoStereo != "B" && monoStereo != "a" && monoStereo != "b")
    {
        Console.WriteLine("\n ERROR: Invalid sound type. Program will terminate.");
        Environment.Exit(0);
    }

    //WAV FILE QUALITY MENU + INPUT
    Console.WriteLine("Choose your WAV file quality:");
    Console.WriteLine("\t A - Standard Quality - 16 bit, 44.1 KHz");
    Console.WriteLine("\t B - Premium Quality - 24 bit, 48 KHz");
    Console.WriteLine("\t B - Ultra Quality - 24 bit, 96 KHz");
    Console.Write("\nEnter your choice of file quality (A, B, or C): ");
    qualityType = Console.ReadLine();

    //validate input
    if (qualityType != "A" && qualityType != "a" && qualityType != "B" &&
        qualityType != "b" && qualityType != "C" && qualityType != "c")
    {
        Console.WriteLine("\n ERROR: Invalid sound type. Program will terminate.");
        Environment.Exit(0);
    }

    if (monoStereo == "A" || monoStereo == "a")
    {
        //mono sound
        output += "\nSound Type: Mono \nFile Quality: ";
        if (qualityType == "A" || qualityType == "a")
        {
            //standard mono wav
            bitrate = MONOSTANDARD;
            output += "Standard Quality - 16 bit, 44.1 KHz";
        }
        else if (qualityType == "B" || qualityType == "b")
        {
            //premium mono wav
            bitrate = MONOPREMIUM;
            output += "Premium Quality - 24 bit, 48 KHz";
        }
        else
        {
            //ultra mono wav
            bitrate = MONOULTRA;
            output += "Ultra Quality - 24 bit, 96 KHz";
        }
    }
    else
    {
        //stereo sound
        output += "\nSound Type: Stereo \nFile Quality: ";
        if (qualityType == "A" || qualityType == "a")
        {
            //standard stereo wav
            bitrate = STEREOSTANDARD;
            output += "Standard Quality - 16 bit, 44.1 KHz";
        }
        else if (qualityType == "B" || qualityType == "b")
        {
            //premium stereo wav
            bitrate = STEREOPREMIUM;
            output += "Premium Quality - 24 bit, 48 KHz";
        }
        else
        {
            //ultra stereo wav
            bitrate = STEREOULTRA;
            output += "Ultra Quality - 24 bit, 96 KHz";
        }
    }
}

//input time duration
Console.WriteLine("\nEnter the duration of the recording in minutes and seconds. (Max: 100 minutes)");
Console.Write("\n\t Enter the minutes: ");
minutes = Convert.ToInt32(Console.ReadLine());

//validate input of minutes
if (minutes < 0 || minutes > 100)
{
    Console.WriteLine("\n ERROR: Invalid sound type. Program will terminate.");
    Environment.Exit(0);
}

if (minutes == 180)
{
    //180 min = secs set to 0
    seconds = 0;
}
else
{
    //seconds input
    Console.Write("\n\t Enter the seconds (Max: 60) ");
    seconds = Convert.ToInt32(Console.ReadLine());
    
    if (seconds < 0 || seconds > 60)
    {
        Console.WriteLine("\nERROR: Invalid seconds entered. Program will terminate.");
        Environment.Exit(0);
    }
}

//time calc
duration = minutes + (double)(seconds / 60.0);

//SUBTOTAL
if (duration <= 10)
{
    subtotal = SUBTOTAL_A;
}
else if (duration <= 30)
{
    subtotal = SUBTOTAL_B;
}
else if (duration <= 60)
{
    subtotal = SUBTOTAL_C;
}
else 
{
    subtotal = SUBTOTAL_D;
}

//file size calc
fileSize = duration * bitrate;

//cost per minute
costPerMin = subtotal / duration;

//cost per mb
costPerMB = subtotal / fileSize;

//calculate tax
tax = subtotal * TAXRATE;

//calculate final cost
total = subtotal + tax;

//output abt file
Console.WriteLine("\n--------------------------------");
Console.Write("{0} \nRecording Duration: ", output);
if (minutes == 1)
    Console.Write("{0} minute", minutes);
else if(minutes > 1)
{
    Console.Write("{0} minutes", minutes);
    if (minutes == 180)
        Console.WriteLine("");
}

if (seconds == 1 && minutes >= 1)
    Console.WriteLine(", 1 second");
else if (seconds > 1 && minutes >= 1)
    Console.WriteLine(", {0} seconds", seconds);
else if (seconds == 1)
    Console.WriteLine("1 second");
else if (seconds > 1)
    Console.WriteLine("{0} seconds", seconds);

Console.WriteLine("File Size: {0} MB", fileSize);
Console.WriteLine("----------------------------");
Console.WriteLine("Subtotal: {0}", subtotal.ToString("c"));
Console.WriteLine("\t Cost Per Min: {0} $/Min", costPerMin.ToString("c"));
Console.WriteLine("\t Cost Per MB: {0} $/MB", costPerMB.ToString("c"));
Console.WriteLine("Streaming Tax: {0}", tax.ToString("c"));
Console.WriteLine("Total Cost: {0}", total.ToString("c"));






