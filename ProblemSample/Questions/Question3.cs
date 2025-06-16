namespace ProblemSample.Questions
{
    /// <summary>
    /// Q3. 01～43までの43個の数字から異なる6個を選択し、出力するプログラムを作成せよ
    /// </summary>
    internal class Question3 : IQuestion
    {
        /// <summary>
        /// 結果取得
        /// </summary>
        /// <param name="args">コンソール引数</param>
        /// <returns>実行結果</returns>
        public string Execute(ReadOnlySpan<string> args)
        {
            const int min = 1;
            const int max = 43;
            const int choiceCount = 6;

            return string.Join($",{Environment.NewLine}", GetRandomNumbers(min, max, choiceCount));
        }

        /// <summary>
        /// 数値範囲からランダムな数値を取得
        /// </summary>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値</param>
        /// <param name="count">選択する数の個数</param>
        /// <returns>選択された数値のリスト</returns>
        private static IEnumerable<int> GetRandomNumbers(int min, int max, int count)
        {
            var range = Enumerable.Range(min, max).ToArray();
            Random.Shared.Shuffle(range);
            return range.Take(count).OrderBy(x => x);
        }
    }
}
