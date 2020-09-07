using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkConfig.Services
{
    public interface IFileService
    {
        bool IsDirectoyOnDisk(string path);

        (bool isSuccess, string path) SelectFolder(string description);
    }
}
