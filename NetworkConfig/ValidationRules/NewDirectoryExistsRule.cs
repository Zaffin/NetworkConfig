using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

using NetworkConfig.Resources;
using NetworkConfig.ViewModels;

namespace NetworkConfig.ValidationRules
{
    public class NewDirectoryExistsRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var bindingExpression = value as BindingExpression;

            if (bindingExpression != null)
            {
                var viewModel = bindingExpression.DataItem as MainWindowViewModel;
                if (viewModel != null)
                {
                    if (!Directory.Exists(viewModel.NewSharedDirectory))
                    {
                        return new ValidationResult(false, UIResources.DirectoryNotFound);

                    }
                }
            }
            return new ValidationResult(true, null);

            //string path = value as string;

            //if (Directory.Exists(path))
            //{
            //    return new ValidationResult(true, null);
            //}
            //else
            //{
            //    return new ValidationResult(false, UIResources.DirectoryNotFound);
            //}                        
        }
    }
}
