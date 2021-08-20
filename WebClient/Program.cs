using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebClient
{
    class Program
    {
        public static async Task Main(string[] args) {
            // 1.Schritt: Starten Sie eine Stopwatch zur Zeitmessung.
            var stopwatch = Stopwatch.StartNew();
            
            // 2.Schritt: Instanzieren Sie einen WebClient
            var clientx = new Client();
            
            // 3.Schritt: Für folgende URL sollen mit der Hilfe des Webclients
            //            Daten heruntergeladen werden. Das Herungerladen der
            //            Daten hat parallel mit Tasks zu erfolgen. Rufen Sie
            //            dazu die folgende Methode auf: WebClient->DownloadHTML
            var urls = new List<string>() {
                "http://www.orf.at", "http://www.news.at"
            };

            var t1 = Task.Run(() => clientx.DownloadHTML(urls[0]));
            var t2 = Task.Run(() => clientx.DownloadHTML(urls[1]));

            var bruh = await Task.WhenAll(t1, t2);
            
            // 4.Schritt: Beenden Sie die Zeitmessung. Geben Sie Daten der Downloads
            //            aus.

            stopwatch.Stop();
            var milliseconds = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"time: {milliseconds}");

            foreach (var x in bruh)
            {
                Console.WriteLine(x);
            }
        }
    }
}