using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeletionTests : TestBase
    {
        [Test]
        public void TestGroupDeletion()
        {
            app.Groups.CheckExistngCreateIfNot();
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData forRemoving = oldGroups[0];

            app.Groups.Remove(forRemoving);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group, forRemoving);
            }
        }
    }
}
