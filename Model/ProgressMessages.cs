using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CloudOps;

namespace Retriever
{
    namespace Model
    {
        public class ProgressMessages : List<InvokationResult>
        {
            public void RetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
            {
                InvokationResult ir = this[e.ItemIndex];
                e.Item = new ListViewItem(ir.Operation.Name);
                e.Item.SubItems.Add(ir.Operation.ServiceName);
                e.Item.SubItems.Add(ir.Operation.Region.DisplayName);                
                if (ir.IsError())
                {
                    e.Item.SubItems.Add(ir.Ex.Message);
                    e.Item.ImageIndex = 2;                    
                } else {
                    e.Item.SubItems.Add(ir.ResultText());
                    e.Item.ImageIndex = 0;
                }
            }            
        }
    }
}

/*
 * string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "SaveFileDialog Export2File";
            sfd.Filter = "Text File (.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    AppSerializer.SaveListView(filename, listViewMessages);                    
                }
            }*/
