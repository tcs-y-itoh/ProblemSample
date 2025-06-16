namespace ProblemSample.Questions
{
    /// <summary>
    /// 課題実行インタフェース
    /// </summary>
    internal interface IQuestion
    {
        /// <summary>
        /// 結果取得
        /// </summary>
        /// <param name="args">コンソール引数</param>
        /// <returns>実行結果</returns>
        public string Execute(ReadOnlySpan<string> args);
    }
}
