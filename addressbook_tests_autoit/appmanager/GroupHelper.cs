﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        internal void Remove(GroupData forRemoving)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.Window.8.app.0.1114f81");
            aux.ControlClick(DELETEGROUPWINTITLE , "", "WindowsForms10.Window.8.app.0.1114f81");
            CloseGroupsDialogue();
        }

        public void CheckExistngCreateIfNot()
        {
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4491", "GetItemCount", "#0", "");
            if (int.Parse(count) == 0)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "test"
                };
                Add(newGroup);
            }
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4491", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4491", "GetText", "#0|#"+i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4493");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4494");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.62e44912");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}