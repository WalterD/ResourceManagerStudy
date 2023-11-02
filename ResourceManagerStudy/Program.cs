using System.Globalization;
using System.Reflection;
using System.Resources;

/*

Setting up resource files - example with English and Spanish:
1. Create folder for resources: Resources
2. Add a resource file, to the project, for the first language: lang.en.resx
   The '.en' part of the file name indicates English language.
3. Add another resource file for another language, for example: lang.es.resx
    The '.es' part of the file name indicates Spanish language.
4. Edit both resource files. Add entries for English and Spanish words/phrases.

Ref: https://www.youtube.com/watch?v=QZtW9S-WvPA&t=2s&ab_channel=Mister_DotNet

 */


// Display information about the current culture.
Console.WriteLine($"Current culture is {Thread.CurrentThread.CurrentUICulture.Name}");
Console.WriteLine($"Parent.Name of the current culture is {Thread.CurrentThread.CurrentUICulture.Parent.Name}");

// Initialize resource manager.
var resourceManager = new ResourceManager(baseName: "ResourceManagerStudy.Resources.Lang",
                                          assembly: Assembly.GetExecutingAssembly());

// Get resource for "Hello" word, for the current culture.
var hello = resourceManager.GetString("Hello");
Console.WriteLine(hello);

// Change the current culture to Spanish.
Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
Console.WriteLine($"Current culture is {Thread.CurrentThread.CurrentUICulture.Name}");
hello = resourceManager.GetString("Hello");
Console.WriteLine(hello);



// Request resource for specific cultures.
var englishCulture = CultureInfo.CreateSpecificCulture("en");
hello = resourceManager.GetString("Hello", englishCulture);
Console.WriteLine($"Hello using {nameof(englishCulture)}: {hello}");

var spanishCulture = CultureInfo.CreateSpecificCulture("es");
hello = resourceManager.GetString("Hello", spanishCulture);
Console.WriteLine($"Hello using {nameof(spanishCulture)}: {hello}");

