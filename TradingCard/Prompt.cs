using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCard
{
    public static class Prompt
    {
        public static string[] ShowDialog(string[] labels, string caption, string[] defaultValues)
        {
            Form prompt = new Form
            {
                Width = 400,
                Height = labels.Length * 50 + 200,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            var inputBoxes = new List<TextBox>();
            int currentHeight = 20;

            foreach (var label in labels)
            {
                Label lbl = new Label
                {
                    Left = 20,
                    Top = currentHeight,
                    Text = label,
                    Width = 340
                };
                prompt.Controls.Add(lbl);

                TextBox inputBox = new TextBox
                {
                    Left = 20,
                    Top = currentHeight + 20,
                    Width = 340,
                    Text = defaultValues.Length > inputBoxes.Count ? defaultValues[inputBoxes.Count] : ""
                };
                inputBoxes.Add(inputBox);
                prompt.Controls.Add(inputBox);

                currentHeight += 60;
            }

            Button confirmation = new Button
            {
                Text = "OK",
                Left = 270,
                Top = currentHeight + 10,
                Width = 100,
                Height = 39,
                DialogResult = DialogResult.OK
            };
            prompt.Controls.Add(confirmation);

            Button cancel = new Button
            {
                Text = "Cancel",
                Left = 150,
                Top = currentHeight + 10,
                Width = 100,
                Height = 39,
                DialogResult = DialogResult.Cancel
            };
            prompt.Controls.Add(cancel);

            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? inputBoxes.Select(x => x.Text).ToArray() : defaultValues;
        }
    }







}
