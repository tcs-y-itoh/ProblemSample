namespace ProblemSample.Questions
{
    /// <summary>
    /// Q2. 引数で与えられた年がうるう年であるか判定するプログラムを作成せよ
    /// </summary>
    internal class Question2 : IQuestion
    {
        /// <summary>
        /// 結果取得
        /// </summary>
        /// <param name="args">コンソール引数</param>
        /// <returns>実行結果</returns>
        public string Execute(ReadOnlySpan<string> args)
        {
            if (!ValidateYear(args, out var year, out var errorMessage))
            {
                return errorMessage;
            }

            return $"{year}年はうるう年{(IsLeapYear(year) ? string.Empty : "ではない")}です。";
        }

        /// <summary>
        /// 年バリデーション
        /// </summary>
        /// <param name="args">コンソール引数</param>
        /// <param name="year">年</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>true：エラーなし false：エラーあり</returns>
        private static bool ValidateYear(ReadOnlySpan<string> args, out int year, out string errorMessage)
        {
            errorMessage = string.Empty;
            year = 0;

            if (args.Length < 2 || !int.TryParse(args[1], out year))
            {
                errorMessage = "第2引数に年の値を数値で入力してください";
                return false;
            }

            if (year < 0)
            {
                errorMessage = "年の値は0以上でなければなりません。";
                return false;
            }

            return true;
        }

        /// <summary>
        /// うるう年判定
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>true：うるう年 false：うるう年ではない</returns>
        private static bool IsLeapYear(int year)
        {
            if (year % 4 != 0)
            {
                return false;
            }

            if (year % 100 == 0)
            {
                return year % 400 == 0;
            }

            return true;
        }
    }
}
