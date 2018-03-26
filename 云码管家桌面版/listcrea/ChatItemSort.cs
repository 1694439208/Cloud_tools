using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DSkin.DirectUI;
using DSkin.Common;

namespace DSkinChatList
{
    /// <summary>
    /// 对列表的项目进行分组排序
    /// </summary>
    class ChatItemSort : IComparer<DuiBaseControl>
    {

        public int Compare(DuiBaseControl x, DuiBaseControl y)
        {
            if (x is GroupItem && y is GroupItem)
            {
                GroupItem X = x as GroupItem;
                GroupItem Y = y as GroupItem;
                if (X.Order > Y.Order)
                {
                    return -1;
                }
                else if (X.Order < Y.Order)
                {
                    return 1;
                }
            }
            else if (x is GroupItem && y is UserItem)
            {
                GroupItem X = x as GroupItem;
                UserItem Y = y as UserItem;
                if (X.Order > Y.GroupId)
                {
                    return -1;
                }
                else if (X.Order < Y.GroupId)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (x is UserItem && y is GroupItem)
            {
                UserItem X = x as UserItem;
                GroupItem Y = y as GroupItem;
                if (Y.Order > X.GroupId)
                {
                    return 1;
                }
                else if (Y.Order < X.GroupId)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (x is UserItem && y is UserItem)
            {
                UserItem X = x as UserItem;
                UserItem Y = y as UserItem;
                if (X.GroupId > Y.GroupId)
                {
                    return -1;
                }
                else if (X.GroupId < Y.GroupId)
                {
                    return 1;
                }
                else if (X.Order > Y.Order)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
