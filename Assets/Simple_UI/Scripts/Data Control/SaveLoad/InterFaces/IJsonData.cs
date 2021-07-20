
namespace yasinfirat
{
    public interface IJsonData
    {
        /// <summary>
        /// Places default data when data is first created
        /// </summary>
        /// <param name="amount">Data amount</param>
        void CheckDataOnLoad(DataScriptable dataScriptable);
    }
}
