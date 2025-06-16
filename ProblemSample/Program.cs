using ProblemSample.Questions;

namespace ProblemSample
{
    /// <summary>
    /// 課題用
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// 課題数
        /// </summary>
        private const int ProblemCount = 3;

        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args">コンソール引数</param>
        public static void Main(string[] args)
        {
            if (!ValidateArgs(args, out var no, out var errorMessage))
            {
                Console.WriteLine(errorMessage);
                return;
            }

            Console.WriteLine(GetProblemResult(no, args));
        }

        /// <summary>
        /// コンソール引数バリデーション
        /// </summary>
        /// <param name="args">コンソール引数</param>
        /// <param name="no">実行課題番号</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>true：エラーなし false：エラーあり</returns>
        private static bool ValidateArgs(ReadOnlySpan<string> args, out int no, out string errorMessage)
        {
            errorMessage = string.Empty;
            no = 0;

            if (args.Length == 0 || !int.TryParse(args[0], out no))
            {
                errorMessage = "第1引数に結果を出力する課題の番号を入力してください。";
                return false;
            }

            if (no < 1 || ProblemCount < no)
            {
                errorMessage = $"課題番号は1から{ProblemCount}の範囲で入力してください。";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 課題実行結果取得
        /// </summary>
        /// <param name="no">実行課題番号</param>
        /// <param name="args">コンソール引数</param>
        /// <returns>課題実行結果</returns>
        private static string GetProblemResult(int no, ReadOnlySpan<string> args)
        {
            IQuestion? question = no switch
            {
                1 => new Question1(),
                2 => new Question2(),
                3 => new Question3(),
                _ => null,
            };

            if (question is null)
            {
                return string.Empty;
            }

            return question.Execute(args);
        }
    }
}
