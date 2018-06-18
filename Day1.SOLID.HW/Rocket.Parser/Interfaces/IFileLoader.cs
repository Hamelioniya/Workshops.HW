using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.Parser.Interfaces
{
    /// <summary>
    /// Интерфейс для загрузки файла
    /// </summary>
    public interface IFileLoader
    {
        /// <summary>
        /// Получает файл по ссылке и сохраняет по указанному пути
        /// </summary>
        /// <param name="url">Ссылка на файл</param>
        /// <param name="path">Путь для сохранения</param>
        /// <returns>Task</returns>
        Task DownloadFile(string url, string path);
    }
}
