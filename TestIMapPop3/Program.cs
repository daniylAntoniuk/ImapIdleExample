using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Search;
using MailKit.Security;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TestIMapPop3
{
    class Program
    {
        static void Main(string[] args)
        {
            DownloadMessages();

        }
        
        public static void DownloadMessages()
        {
            //using (var client = new ImapClient())
            //{
            //    client.Connect("danik22122005.realhost-free.net", 993, SecureSocketOptions.Auto);

            //    client.Authenticate("daniyl@jobjoin.tk", "Qwerty-1");
            //    client.Inbox.Open(FolderAccess.ReadOnly);

            //    var uids = client.Inbox.Search(SearchQuery.All);
            //    foreach (var uid in uids)
            //    {
            //        var message = client.Inbox.GetMessage(uid);

            //        // write the message to a file
            //        message.WriteTo(string.Format("{0}.eml", uid));
            //    }

            //    client.Disconnect(true);
            //}
            using (var client = new IdleClient("danik22122005.realhost-free.net", 993,SecureSocketOptions.Auto, "daniyl@jobjoin.tk", "Qwerty-1"))
            {
                Console.WriteLine("Hit any key to end the demo.");

                var idleTask = client.RunAsync();

                Task.Run(() => {
                    Console.ReadKey(true);
                }).Wait();

                client.Exit();

                idleTask.GetAwaiter().GetResult();
            }
        }
    }
}
