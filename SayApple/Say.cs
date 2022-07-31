using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CliWrap;

namespace SayApple
{
    public static class Say
    {
        /// <summary>
        /// The system outputs the given text with systems default speech.
        /// </summary>
        /// <param name="text">The text to say.</param>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        /// <returns></returns>
        public static async Task SayAsync(string text)
        {
            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            var result = await Cli.Wrap("say")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(standardOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(standardError))
                .WithArguments("\"" + text + "\"").ExecuteAsync();
            if (result.ExitCode != 0)
            {
                throw new SayCommandException(result, standardOutput.ToString(), standardError.ToString());
            }
        }

        /// <summary>
        /// The system outputs the given text with the given speech.
        /// </summary>
        /// <param name="text">The text to say.</param>
        /// <param name="speech">The name of the speech.</param>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        /// <returns></returns>
        public static async Task SayAsync(string text, string speech)
        {
            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            var result = await Cli.Wrap("say")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(standardOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(standardError))
                .WithArguments(args => args
                    .Add("-v").Add(speech)
                    .Add("\"" + text + "\"")
                ).ExecuteAsync();
            if (result.ExitCode != 0)
            {
                throw new SayCommandException(result, standardOutput.ToString(), standardError.ToString());
            }
        }

        /// <summary>
        /// The system outputs the given text with the given speech.
        /// </summary>
        /// <param name="text">The text to say.</param>
        /// <param name="speech">The speech. This can be gotten from GetInstalledSpeechesAsync-method.</param>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        /// <returns></returns>
        public static async Task SayAsync(string text, Speech speech)
        {
            await SayAsync(text, speech.Name);
        }

        /// <summary>
        /// Reads the text into a soundfile. The systems default speech is used.
        /// </summary>
        /// <param name="text">The text to read.</param>
        /// <param name="outputFile">The filename/filepath of the file to create. It needs to be a supported file format like AIFF (.aiff).</param>
        /// <returns></returns>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        public static async Task ReadToFileAsync(string text, string outputFile)
        {
            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            var result = await Cli.Wrap("say")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(standardOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(standardError))
                .WithArguments(args => args
                    .Add("-o").Add("\"" + outputFile + "\"")
                    .Add("\"" + text + "\"")
                ).ExecuteAsync();
            if (result.ExitCode != 0)
            {
                throw new SayCommandException(result, standardOutput.ToString(), standardError.ToString());
            }
        }

        /// <summary>
        /// Reads the text into a soundfile.
        /// </summary>
        /// <param name="text">The text to read.</param>
        /// <param name="outputFile">The filename/filepath of the file to create. It needs to be a supported file format like AIFF (.aiff).</param>
        /// <param name="speech">The name of the speech to use.</param>
        /// <returns></returns>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        public static async Task ReadToFileAsync(string text, string outputFile, string speech)
        {
            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            var result = await Cli.Wrap("say")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(standardOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(standardError))
                .WithArguments(args => args
                    .Add("-v").Add(speech)
                    .Add("-o").Add("\"" + outputFile + "\"")
                    .Add("\"" + text + "\"")
                ).ExecuteAsync();
            if (result.ExitCode != 0)
            {
                throw new SayCommandException(result, standardOutput.ToString(), standardError.ToString());
            }
        }

        /// <summary>
        /// Reads the text into a soundfile.
        /// </summary>
        /// <param name="text">The text to read.</param>
        /// <param name="outputFile">The filename/filepath of the file to create. It needs to be a supported file format like AIFF (.aiff).</param>
        /// <param name="speech">The speech. This can be gotten from GetInstalledSpeechesAsync-method.</param>
        /// <returns></returns>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        public static async Task ReadToFileAsync(string text, string outputFile, Speech speech)
        {
            await ReadToFileAsync(text, outputFile, speech.Name);
        }

        /// <summary>
        /// The system reads the text out loud from a text-file. Uses the systems default speech.
        /// </summary>
        /// <param name="textFile">The filename/filepath of the file to read from. This should be a plain text file like a .txt, where it is only the text plus eventually some supported tags.</param>
        /// <returns></returns>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        public static async Task SayFromFileAsync(string textFile)
        {
            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            var result = await Cli.Wrap("say")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(standardOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(standardError))
                .WithArguments(args => args
                    .Add("-f").Add("\"" + textFile + "\"")
                ).ExecuteAsync();
            if (result.ExitCode != 0)
            {
                throw new SayCommandException(result, standardOutput.ToString(), standardError.ToString());
            }
        }

        /// <summary>
        /// The system reads the text out loud from a text-file. Uses the systems default speech.
        /// </summary>
        /// <param name="textFile">The filename/filepath of the file to read from. This should be a plain text file like a .txt, where it is only the text plus eventually some supported tags.</param>
        /// <param name="speech">The name of the speech to use.</param>
        /// <returns></returns>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        public static async Task SayFromFileAsync(string textFile, string speech)
        {
            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            var result = await Cli.Wrap("say")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(standardOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(standardError))
                .WithArguments(args => args
                    .Add("-f").Add("\"" + textFile + "\"")
                    .Add("-v").Add(speech)
                ).ExecuteAsync();
            if (result.ExitCode != 0)
            {
                throw new SayCommandException(result, standardOutput.ToString(), standardError.ToString());
            }
        }

        /// <summary>
        /// The system reads the text out loud from a text-file. Uses the systems default speech.
        /// </summary>
        /// <param name="textFile">The filename/filepath of the file to read from. This should be a plain text file like a .txt, where it is only the text plus eventually some supported tags.</param>
        /// <param name="speech">The speech. This can be gotten from GetInstalledSpeechesAsync-method.</param>
        /// <returns></returns>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        public static async Task SayFromFileAsync(string textFile, Speech speech)
        {
            await SayFromFileAsync(textFile, speech.Name);
        }

        /// <summary>
        /// The system reads the text from a text-file and into a soundfile. Uses the systems default speech.
        /// </summary>
        /// <param name="textFile">The filename/filepath of the file to read from. This should be a plain text file like a .txt, where it is only the text plus eventually some supported tags.</param>
        /// <param name="outputFile">The filename/filepath of the file to create. It needs to be a supported file format like AIFF (.aiff).</param>
        /// <returns></returns>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        public static async Task ReadFromFileToFileAsync(string textFile, string outputFile)
        {
            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            var result = await Cli.Wrap("say")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(standardOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(standardError))
                .WithArguments(args => args
                    .Add("-f").Add("\"" + textFile + "\"")
                    .Add("-o").Add("\"" + outputFile + "\"")
                ).ExecuteAsync();
            if (result.ExitCode != 0)
            {
                throw new SayCommandException(result, standardOutput.ToString(), standardError.ToString());
            }
        }

        /// <summary>
        /// The system reads the text from a text-file and into a soundfile.
        /// </summary>
        /// <param name="textFile">The filename/filepath of the file to read from. This should be a plain text file like a .txt, where it is only the text plus eventually some supported tags.</param>
        /// <param name="outputFile">The filename/filepath of the file to create. It needs to be a supported file format like AIFF (.aiff).</param>
        /// <param name="speech">The name of the speech to use.</param>
        /// <returns></returns>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        public static async Task ReadFromFileToFileAsync(string textFile, string outputFile, string speech)
        {
            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            var result = await Cli.Wrap("say")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(standardOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(standardError))
                .WithArguments(args => args
                    .Add("-f").Add("\"" + textFile + "\"")
                    .Add("-o").Add("\"" + outputFile + "\"")
                    .Add("-v").Add(speech)
                ).ExecuteAsync();
            if (result.ExitCode != 0)
            {
                throw new SayCommandException(result, standardOutput.ToString(), standardError.ToString());
            }
        }

        /// <summary>
        /// The system reads the text from a text-file and into a soundfile.
        /// </summary>
        /// <param name="textFile">The filename/filepath of the file to read from. This should be a plain text file like a .txt, where it is only the text plus eventually some supported tags.</param>
        /// <param name="outputFile">The filename/filepath of the file to create. It needs to be a supported file format like AIFF (.aiff).</param>
        /// <param name="speech">The speech. This can be gotten from GetInstalledSpeechesAsync-method.</param>
        /// <returns></returns>
        /// <exception cref="SayCommandException">If something went wrong when executing command.</exception>
        public static async Task ReadFromFileToFileAsync(string textFile, string outputFile, Speech speech)
        {
            await ReadFromFileToFileAsync(textFile, outputFile, speech.Name);
        }

        
        public static async Task<List<Speech>> GetInstalledSpeechesAsync()
        {
            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            var result = await Cli.Wrap("say")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(standardOutput))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(standardError))
                .WithArguments(args => args
                    .Add("-v").Add("?")
                ).ExecuteAsync();
            if (result.ExitCode != 0)
            {
                throw new SayCommandException(result, standardOutput.ToString(), standardError.ToString());
            }

            var speeches = new List<Speech>();
            foreach(var entry in standardOutput.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                var entrySplit1 = entry.Split(new[] { ' ' }, 2);
                var name = entrySplit1[0].Trim();
                var entrySplit2 = entrySplit1[1].Split(new[] { '#' }, 2);
                var countryCode = entrySplit2[0].Trim();
                var quote = entrySplit2[1].Trim();
                speeches.Add(new Speech(name, countryCode, quote));
            }

            return speeches;
        }
    }
}

