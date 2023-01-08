using System.Speech.Synthesis;

var synthesizer = new SpeechSynthesizer();
synthesizer.SetOutputToDefaultAudioDevice();

var voices = synthesizer.GetInstalledVoices();
for (var i = 0; i < voices.Count; i++)
    Console.WriteLine($"{i}: {voices[i].VoiceInfo.Name}:{voices[i].Enabled}");

while(true)
{
    var chosenVoiceIndex = -1;
    while (chosenVoiceIndex == -1)
    {
        Console.Write("Input the index of your chosen voice: ");

        var input = Console.ReadLine();

        if (input == null)
        {
            Console.WriteLine("Input is null");
            break;
        }

        try
        {
            chosenVoiceIndex = int.Parse(input);
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to parse input!");
            break;
        }

        if (chosenVoiceIndex < 0 || chosenVoiceIndex > voices.Count)
        {
            Console.WriteLine("Input doesn't match a voice index!");
            break;
        }
    }

    Console.Write("Voice output: ");
    synthesizer.SelectVoice(voices[chosenVoiceIndex].VoiceInfo.Name);

    var voiceInput = Console.ReadLine();

    synthesizer.Speak(voiceInput);
}