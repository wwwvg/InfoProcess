using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;

namespace Information.Helpers
{
    internal class UpdateProcessesList
    {
        public static void Update<T>(ObservableCollection<T> currentList, List<T> newList)
        {  
            var processesToDelete = currentList.Except(newList); // процессы, которых больше нет
            var processesToAdd = newList.Except(currentList); // новые процессы, которых нет в списке

            foreach(var process in processesToDelete.ToList<T>())
                currentList.Remove(process);

            foreach (var process in processesToAdd.ToList<T>())
                currentList.Add(process);

        } 
    }
}
