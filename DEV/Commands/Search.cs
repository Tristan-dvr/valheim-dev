using System;
using System.Linq;

namespace DEV {

  ///<summary>New command to search to list object or location ids.</summary>
  public class SearchCommand : BaseCommand {
    public SearchCommand() {
      new Terminal.ConsoleCommand("search", "[term] [max_lines=5] - Prints object ids matching the search term.", delegate (Terminal.ConsoleEventArgs args) {
        if (args.Length < 2) return;
        var term = args[1].ToLower();
        var maxLines = TryParameterInt(args.Args, 2, 5);
        var objects = ParameterInfo.Ids.Where(id => id.ToLower().Contains(term)).ToArray();
        var bufferSize = (int)Math.Ceiling((float)objects.Length / maxLines);
        var buffer = new string[bufferSize];
        for (int i = 0; i < objects.Length; i += bufferSize) {
          if (objects.Length - i < bufferSize) {
            bufferSize = objects.Length - i;
            buffer = new string[bufferSize];
          }
          Array.Copy(objects, i, buffer, 0, bufferSize);
          args.Context.AddString(string.Join(", ", buffer));
        }
      }, optionsFetcher: () => ParameterInfo.Create("Search term"));
      AutoComplete.Register("search", (int index) => {
        if (index == 0) return ParameterInfo.Create("Search term");
        if (index == 1) return ParameterInfo.Create("Max lines", "number (default 5)");
        return null;
      });
    }
  }
}
