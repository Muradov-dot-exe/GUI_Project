using Draw.src.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	[Serializable]
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	
		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			
				if (MessageBox.Show("Do you want to save changes?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{

						dialogProcessor.MySerialize(dialogProcessor.ShapeList, saveFileDialog1.FileName);
					}
				}
				
			
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);

		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var sel1 = dialogProcessor.ContainsPoint(e.Location);

				if (sel1 != null)
				{

					if (dialogProcessor.ShapeList.Contains(sel1))
					{
						contextMenuStrip1.Show(this, new Point(e.X, e.Y));

						dialogProcessor.SelectionMenu = sel1;

					}
				}
				else
				{
					if (dialogProcessor.SelectionMenu != null)
					{
						contextMenuStrip2.Show(this, new Point(e.X, e.Y));
						if (dialogProcessor.Coppy != null)
						{
							dialogProcessor.Coppy = new PointF(e.X, e.Y);
						}
					}
				}
			}
			if (pickUpSpeedButton.Checked)
			{
				var sel = dialogProcessor.ContainsPoint(e.Location);

				if (sel != null)
				{
					if (dialogProcessor.Selection.Contains(sel))
						dialogProcessor.Selection.Remove(sel);
					else
						dialogProcessor.Selection.Add(sel);

					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					viewPort.Invalidate();
				}
			}

		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomEllipse();

			statusBar.Items[0].Text = "Последно действие: Рисуване на ellipse";

			viewPort.Invalidate();
		}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomSquare();

			statusBar.Items[0].Text = "Последно действие: Рисуване на square";

			viewPort.Invalidate();
		}

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

			dialogProcessor.AddRandomLine();

			statusBar.Items[0].Text = "Последно действие: Рисуване на line";

			viewPort.Invalidate();
		}

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void viewPort_Load(object sender, EventArgs e)
        {

        }

      

        private void speedMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pickUpSpeedButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomPolygon();

			statusBar.Items[0].Text = "Последно действие: Рисуване на polygon";

			viewPort.Invalidate();
		}

   
        private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomTriangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";

			viewPort.Invalidate();
		}

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
			/*Displays a SaveFileDialog so the user can save the Image
			// assigned to Button2.
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
			saveFileDialog1.Title = "Save an Image File";
			saveFileDialog1.ShowDialog();

			// If the file name is not an empty string open it for saving.
			if (saveFileDialog1.FileName != "")
			{
				// Saves the Image via a FileStream created by the OpenFile method.
				System.IO.FileStream fs =
					(System.IO.FileStream)saveFileDialog1.OpenFile();
				// Saves the Image in the appropriate ImageFormat based upon the
				// File type selected in the dialog box.
				// NOTE that the FilterIndex property is one-based.
				switch (saveFileDialog1.FilterIndex)
				{
					case 1:
						this.saveToolStripMenuItem.Image.Save(fs,
						  System.Drawing.Imaging.ImageFormat.Jpeg);
						break;

					case 2:
						this.saveToolStripMenuItem.Image.Save(fs,
						  System.Drawing.Imaging.ImageFormat.Bmp);
						break;

					case 3:
						this.saveToolStripMenuItem.Image.Save(fs,
						  System.Drawing.Imaging.ImageFormat.Gif);
						break;
				}

				fs.Close();
			}*/
			if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{

				dialogProcessor.MySerialize(dialogProcessor.ShapeList, saveFileDialog1.FileName);
			}


		}

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				dialogProcessor.ShapeList = (List<Shape>)dialogProcessor.MyDeSerialize(openFileDialog1.FileName);
				viewPort.Invalidate();
			}
		}

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
			dialogProcessor.GroupSelected();
			statusBar.Items[0].Text = "Последно действие: Групиране";
			viewPort.Invalidate();
		}

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
			dialogProcessor.ReGroup();
			statusBar.Items[0].Text = "Последно действие: Разгрупиране";
			viewPort.Invalidate();
		}

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SetSelectedFieldColor(colorDialog1.Color);
				viewPort.Invalidate();
			}
		}

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SetSelectedBorderColor(colorDialog1.Color);
				statusBar.Items[0].Text = "Последно действие: Промяна на цвета на кунтура";
				viewPort.Invalidate();
			}
		}

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (MessageBox.Show("Do you want to save changes?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{

					dialogProcessor.MySerialize(dialogProcessor.ShapeList, saveFileDialog1.FileName);
				}
			}
			dialogProcessor.ShapeList.Clear();
			viewPort.Invalidate();
		}

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.CopySelected();
			statusBar.Items[0].Text = "Последно действие: Копиране на селектираните примитиви";
			viewPort.Invalidate();
		}

        private void завъртанеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Dialog eventForm = new Dialog("rotate", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Последно действие: Завъртане";
			viewPort.Invalidate();
		}

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void плътностToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Dialog eventForm = new Dialog("opacity", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Последно действие: Задаване на прозрачност";
			viewPort.Invalidate();
		}

        private void дебелинаНаРамкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Dialog eventForm = new Dialog("border width", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Последно действие: Задавене на дебелина на контур";
			viewPort.Invalidate();
		}

        private void преразмеряванеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Dialog eventForm = new Dialog("resize", dialogProcessor);
			eventForm.ShowDialog();
			statusBar.Items[0].Text = "Последно действие: Преоразмеряване";
			viewPort.Invalidate();
		}

        private void правоъгълникToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomRectangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на rectangle";

			viewPort.Invalidate();
		}

        private void елипсаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomEllipse();

			statusBar.Items[0].Text = "Последно действие: Рисуване на ellipse";

			viewPort.Invalidate();

		}

        private void триъгълникToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomTriangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на triangle";

			viewPort.Invalidate();
		}

        private void квадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomSquare();

			statusBar.Items[0].Text = "Последно действие: Рисуване на square";

			viewPort.Invalidate();
		}

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
			
				dialogProcessor.AddRandomIZPITshape();

				statusBar.Items[0].Text = "Последно действие: Рисуване на IZPITshape";

				viewPort.Invalidate();
			
		}

        private void изпитФигураToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomIZPITshape();

			statusBar.Items[0].Text = "Последно действие: Рисуване на IZPITshape";

			viewPort.Invalidate();
		}
    }
    }
    

