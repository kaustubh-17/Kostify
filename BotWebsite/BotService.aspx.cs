using System;
using System.Web;
using System.Web.UI;
using Syn.Bot.Channels.Testing;
using Syn.Bot.Channels.Widget;
using Syn.Bot.Oscova;

namespace BotWebsite
{
    public partial class BotService : Page
    {
        private static WidgetChannel WidgetChannel { get; }
        private static OscovaBot Bot { get; }

        static BotService()
        {
            Bot = new OscovaBot();
            WidgetChannel = new WidgetChannel(Bot);

            //Add the pre-built channel test dialog.
            Bot.Dialogs.Add(new ChannelTestDialog(Bot));

            //Start training.
            Bot.Trainer.StartTraining();

            var websiteUrl =
                HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            WidgetChannel.ServiceUrl = websiteUrl + "/BotService.aspx";
            WidgetChannel.ResourceUrl = websiteUrl + "/BotResources";

            WidgetChannel.WidgetTitle = "Our Smart Bot!";
            WidgetChannel.LaunchButtonText = "Ask";
            WidgetChannel.InputPlaceHolder = "Ask your query here...";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            WidgetChannel.Process(Request, Response);
        }
    }
}