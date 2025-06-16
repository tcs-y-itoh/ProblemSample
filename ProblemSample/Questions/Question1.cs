namespace ProblemSample.Questions
{
    /// <summary>
    /// Q1. 1から100までの数のうち、素数のみ出力するプログラムを作成せよ
    /// </summary>
    internal class Question1 : IQuestion
    {
        /// <summary>
        /// 結果取得
        /// </summary>
        /// <param name="args">コンソール引数</param>
        /// <returns>実行結果</returns>
        public string Execute(ReadOnlySpan<string> args)
        {
            const int start = 1;
            const int end = 100;

            return string.Join($",{Environment.NewLine}", GetPrimeNumbers(start, end));

        }

        /// <summary>
        /// 素数リスト取得
        /// </summary>
        /// <param name="start">開始番号</param>
        /// <param name="end">終了番号</param>
        /// <returns>素数リスト</returns>
        private static IEnumerable<int> GetPrimeNumbers(int start, int end)
        {
            foreach (var number in Enumerable.Range(start, end))
            {
                if (IsPrime(number))
                {
                    yield return number;
                }
            }
        }

        /// <summary>
        /// 素数判定
        /// </summary>
        /// <param name="number">数値</param>
        /// <returns>true：素数 false：素数ではない</returns>
        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            var judgeArray = new bool[number + 1];
            var limit = (int)Math.Sqrt(number);

            for (var i = 2; i <= limit; i++)
            {
                if (judgeArray[i])
                {
                    continue;
                }

                for (var j = i * i; j <= number; j += i)
                {
                    judgeArray[j] = true;
                }
            }

            return !judgeArray[number];
        }
    }
}
