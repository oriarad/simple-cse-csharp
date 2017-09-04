# simple-cse-csharp
C# version for SimpleCSE Package

  
# Installation
Probably the easiest way to instal the **SimpleCSE** package to a Visual-Studio project is using **nuget**:  
In a new Visual-Studio project, open *Tools :arrow_right: NuGet Package Manager :arrow_right: Package Manager Console* 
  
![](http://csharpcorner.mindcrackerinc.netdna-cdn.com/UploadFile/8a67c0/use-nuget-package-manager-in-visual-studio-2015/Images/choose%20Package%20Manager%20Console.jpg)  
Then write in the PM console:  
```PowerShell
install-package SimpleCSE
```
That's it!
  
# First Example
```csharp
SimpleRss rss = new SimpleRss("http://rss.cnn.com/rss/edition.rss");
for (int i = 0; i < rss.GetSize(); ++i)
{
    Console.WriteLine(rss.GetItem(i).GetTitle());
}
```
  
