namespace ProblemSample.Questions
{
    /// <summary>
    /// Q1. 1から100までの数のうち、素数のみ出力するプログラムを作成せよ
    /// </summary>
    internal class Question1: IQuestion
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
            if (end < 2 || start > end)
            {
                yield break;
            }

            var isPrimeArray = Enumerable.Range(0, end + 1).Select(x => true).ToArray();
            var limit = (int)Math.Sqrt(end);

            for (var i = 2; i <= limit; i++)
            {
                if (!isPrimeArray[i])
                {
                    continue;
                }

                for (var j = i * i; j <= end; j += i)
                {
                    isPrimeArray[j] = false;
                }
            }

            for (var i = Math.Max(start, 2); i <= end; i++)
            {
                if (isPrimeArray[i])
                {
                    yield return i;
                }
            }
        }
    }
}
