﻿using Microsoft.SharePoint.Client;
using PnP.Framework.Pages;

using PnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Management.Automation;

namespace PnP.PowerShell.Commands.ClientSidePages
{
    [Cmdlet(VerbsCommon.Add, "PnPClientSidePage")]
    public class AddClientSidePage : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Name = null;

        [Parameter(Mandatory = false)]
        public ClientSidePageLayoutType LayoutType = ClientSidePageLayoutType.Article;

        [Parameter(Mandatory = false)]
        public ClientSidePagePromoteType PromoteAs = ClientSidePagePromoteType.None;

        [Parameter(Mandatory = false)]
        public ContentTypePipeBind ContentType;

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter CommentsEnabled = false;

        [Parameter(Mandatory = false)]
        public SwitchParameter Publish;

        [Parameter(Mandatory = false)]
        public ClientSidePageHeaderLayoutType HeaderLayoutType = ClientSidePageHeaderLayoutType.FullWidthImage;

        protected override void ExecuteCmdlet()
        {
            ClientSidePage clientSidePage = null;

            // Check if the page exists
            string name = ClientSidePageUtilities.EnsureCorrectPageName(Name);

            bool pageExists = false;
            try
            {
                ClientSidePage.Load(ClientContext, name);
                pageExists = true;
            }
            catch { }

            if (pageExists)
            {
                throw new Exception($"Page {name} already exists");
            }

            // Create a page that persists immediately
            clientSidePage = CurrentWeb.AddClientSidePage(name);
            clientSidePage.LayoutType = LayoutType;
            clientSidePage.PageHeader.LayoutType = HeaderLayoutType;

            if (PromoteAs == ClientSidePagePromoteType.Template)
            {
                clientSidePage.SaveAsTemplate(name);
            }
            else
            {
                clientSidePage.Save(name);
            }

            if (ContentType != null)
            {
                string ctId = ContentType.GetIdOrThrow(nameof(ContentType), CurrentWeb);
                clientSidePage.PageListItem["ContentTypeId"] = ctId;
                clientSidePage.PageListItem.SystemUpdate();
                ClientContext.ExecuteQueryRetry();
            }

            // If a specific promote type is specified, promote the page as Home or Article or ...
            switch (PromoteAs)
            {
                case ClientSidePagePromoteType.HomePage:
                    clientSidePage.PromoteAsHomePage();
                    break;
                case ClientSidePagePromoteType.NewsArticle:
                    clientSidePage.PromoteAsNewsArticle();
                    break;
                case ClientSidePagePromoteType.None:
                default:
                    break;
            }

            if (ParameterSpecified(nameof(CommentsEnabled)))
            {
                if (CommentsEnabled)
                {
                    clientSidePage.EnableComments();
                }
                else
                {
                    clientSidePage.DisableComments();
                }
            }

            if (Publish)
            {
                clientSidePage.Publish();
            }

            WriteObject(clientSidePage);
        }
    }
}