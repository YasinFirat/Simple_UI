namespace yasinfirat
{
    public interface IOnload
    {
        /// <summary>
        /// if the folder does not exist, create 
        /// </summary>
        /// <param name="path">file path</param>
         void CheckFolder(string path);

        /// <summary>
        ///  if the file does not exist, create 
        /// </summary>
        /// <param name="path">file must to be .json, .txt, .doc etc. </param>
         void CheckFile(string file); 

    }
}
