using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using Application = Microsoft.Office.Interop.Word.Application;
using Range = Microsoft.Office.Interop.Word.Range;
using Ascan;

namespace AUT
{
    class WordFunction
    {

        public Application wordApp = null;
        public Document wordDoc = null;
        private List<Table> tablelist = new List<Table>();

        public bool Creat(string filePath)
        {
            KillWinWordProcess();
            //run word
            wordApp = new Application();
            wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            wordApp.Visible = false;
            object missing = System.Reflection.Missing.Value;
            object templateName = filePath;
            //open document
            wordDoc = wordApp.Documents.Open(ref templateName, ref missing,
              ref missing, ref missing, ref missing, ref missing, ref missing,
              ref missing, ref missing, ref missing, ref missing, ref missing,
              ref missing, ref missing, ref missing, ref missing);

            if (wordDoc == null)
                return false;
            else
                return true;
        }

        public void SaveDocument(string filePath)
        {
            object fileName = filePath;
            object format = WdSaveFormat.wdFormatDocument;//save mode
            object miss = System.Reflection.Missing.Value;
            wordDoc.SaveAs(ref fileName, ref format, ref miss,
                  ref miss, ref miss, ref miss, ref miss,
                  ref miss, ref miss, ref miss, ref miss,
                  ref miss, ref miss, ref miss, ref miss,
                  ref miss);

            //close wordDoc，wordApp
            object SaveChanges = WdSaveOptions.wdSaveChanges;
            object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;
            wordDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            wordApp.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
        }

        public bool InsertValue(string bookmark, string value)
        {
            object bkObj = bookmark;
            if (wordDoc.Bookmarks.Exists(bookmark))
            {
                wordDoc.Bookmarks.get_Item(ref bkObj).Select();
                wordApp.Selection.TypeText(value);
                return true;
            }
            return false;
        }

        public Table InsertTable(string bookmark, int rows, int columns, float width, float height)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            Range range = wordDoc.Bookmarks.get_Item(ref oStart).Range;
            Table newTable = wordDoc.Tables.Add(range, rows, columns, ref miss, ref miss);
            //Set format
            newTable.Borders.Enable = 1;
            newTable.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth050pt;//边框宽度
            if (width != 0)
            {
                newTable.Rows.SetHeight(height, WdRowHeightRule.wdRowHeightAuto);
                newTable.PreferredWidth = width;//表格宽度
            }
            newTable.AllowPageBreaks = false;
            return newTable;
        }

        public void InsertCell(Table table, int row, int column, string value)
        {
            table.Cell(row, column).Range.Text = value;
        }

        public void InsertPicture(string bookmark, string picturePath, float width, float hight)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            Object linkToFile = false;    //图片是否为外部链接
            Object saveWithDocument = true; //图片是否随文档一起保存
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//图片插入位置
            wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocument, ref range);
            if (width != 0 && hight != 0)
            {
                wordDoc.Application.ActiveDocument.InlineShapes[1].Width = width; //设置图片宽度
                wordDoc.Application.ActiveDocument.InlineShapes[1].Height = hight; //设置图片高度
            }
        }

        public void InsertText(string bookmark, string text)
        {
            object oStart = bookmark;
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;
            Paragraph wp = wordDoc.Content.Paragraphs.Add(ref range);
            wp.Format.SpaceBefore = 6;
            wp.Range.Text = text;
            wp.Format.SpaceAfter = 24;
            wp.Range.InsertParagraphAfter();
            wordDoc.Paragraphs.Last.Range.Text = "\n";
        }

        public void KillWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }
    }
}
