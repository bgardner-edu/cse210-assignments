using System;

static class Prompts
{
    public static string GetRandomPrompt()
    {
        List<string> prompts = [
            "What happened today?",
            "What was the best thing that happened today?",
            "What was the worst thing that happened today?",
            "What was the most interesting thing I saw or heard today?",
            "What was the most challenging thing I faced today?",
            "What am I grateful for today?",
            "What did I learn today?",
            "What was the most fun thing I did today?",
            "What was the most surprising thing that happened today?",
            "What did I do today that I am proud of?",
        ];
        Random random = new Random();
        var num = random.Next(1, prompts.Count);
        return prompts[num];
    }
}