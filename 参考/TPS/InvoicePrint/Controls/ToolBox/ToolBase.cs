﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using  CustomControls;
using System.Drawing;
using  CustomControls.DrawItem;
/******************************************************************
 * Copyright(c)  : 徐春晓
 * CreateDate    : 2008-10-21 22:55
 * Creater       : CraxyMouse
 * LastChangeDate: 
 * LastChanger   : CraxyMouse
 * Version Info  : 1.0.1
 * Author        : CraxyMouse
 * Mail          : 9658258@qq.com
 * MSN           : chunxiaodyl@hotmail.com
 * Blog          : http://blog.csdn.net/dunao
 * Description   : 如果您使用此源程序或是提供下载，不可修改资助信息。以示对我的劳动成果的尊重！谢谢您的合作！否则请您不要提供下载或使用
 *                 源代码中CODE 39[CODE93,CODE 128A,CODE 128B,CODE 128C,EAN-13,UPC-A尚未添加,需要请发邮件给我!]的条码为有尝使用,如果您使用了这些代码请您
 *                 根据资助信息里的资助信息,支付RMB:10元以上的使用费用!给您带来不便还望谅解!如有问题你也可以直接和我
 *                 交流,我将知无不言!
 * ******************************************************************
 *本程序为开源程序。所有代码可以任意复制和使用，请您在使用的时候请保留版权信息，以示对我支持！谢谢！！同时要感谢AnsenYu支持！！！
  如果有任何关于程序方面的问题和意见请联系我！QQ群:47717908 Mail:9658258@qq.com我将会在第一时间内解答您的问题！
 * 首先谢谢您的资助!您可以通过以下几种方式资助:
    1.支付宝直接转帐：
          帐号：xutongchun@163.com
          姓名：徐春晓
    2.银行帐号直接转帐：
          开户行：招商银行苏州园区支行
          帐  号：6225  8851  2367  5829
          开户名：徐春晓
          
          开户行：农业银行苏州干将路支行
          帐  号：62284 8040 03789 32919
          开户名：徐春晓
    3.淘宝物品购买:
          物品地址:
 *                  http://auction1.taobao.com/auction/item_detail-0db2-c9d9d9663b8053dcebecbe17d8a4bbda.jhtml
 *                  
 */
namespace CustomControls.ToolBox
{
    public class ToolBase
    {
        public ToolBase()
        { 
        }

        private Dictionary<string, Cursor> cursor = new Dictionary<string, Cursor>();
        private Cursor _cursor;

        /// <summary>
        /// 从资源文件里读取光标文件
        /// 如果在没有加载过的光标，则先从资源文件里读取
        /// 加载过的直接从dictionary中返回
        /// </summary>
        /// <param name="name">光标的名称,不带扩展名</param>
        /// <returns></returns>
        protected Cursor GetCursor(string name)
        {
            if (cursor.ContainsKey(name))
            {
                return cursor[name];
            }
            using (Stream fs = Assembly.GetAssembly(typeof(ToolBase)).GetManifestResourceStream("CustomControls.Resources." + name + ".cur"))
            {
                Cursor c = new Cursor(fs);
                cursor.Add(name, c);
                return c;
            }
 
        }

        protected void AddNewObject(Designer designer, CustomControls.DrawItem.DrawItemBase drawitem)
        {
            //在设计器对像列表中加入新的对像
            designer.Items.Add(drawitem);
            //将原来选中的对像设计为未选中
            designer.Items.UnSelectAll();
            //设置新添加的对像为选中状态
            drawitem.Selected = true;

            designer.Capture = true;
            designer.Refresh();

            designer.ChangeFlage = true;
        }

        /// <summary>
        /// 设置所选择工具的光标
        /// </summary>
        public Cursor ToolCursor
        {
            get 
            {
                return _cursor;
            }
            set
            {
                _cursor = value;
            }
        }

        public virtual void OnMouseDown(Designer designer, MouseEventArgs e)
        { 
        }

        public virtual void OnMouseMove(Designer designer, MouseEventArgs e)
        { 
        }

        public virtual void OnMouseUp(Designer designer, MouseEventArgs e)
        { 
            
        }

        public virtual void OnDoubleClick(Designer designer, MouseEventArgs e)
        {
            
        }

    }
}
