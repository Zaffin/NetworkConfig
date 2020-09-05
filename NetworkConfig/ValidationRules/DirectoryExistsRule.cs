using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NetworkConfig.ValidationRules
{
    public class DirectoryExistsRule : ValidationRule
    {
        public int MinimumCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string path = value as string;

            if (Directory.Exists(path))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, $"The selected directory does not exist");
            }                        
        }
    }
}
