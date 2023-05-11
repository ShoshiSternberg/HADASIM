#אם רוצים שמפרט גדלי הטוויטר יראו בתצוגה
#עיצוב למפרט נפתח
#לקוד מגדלי הטוויטר יש לעבור לעמוד Twitter towers שבפרוקיט זה
import tkinter as tk
from tkinter import ttk

def handle_selection(event):
    option = dropdown.get()
    if option=="בחירת מגדל מלבן":
        option=1
    if option == "בחירת מגדל משולש":
        option = 2
    if option == "יציאה מהתוכנית":
        option = 3
    print("Selected item:", option)


# Create the main window
window = tk.Tk()
window.title("Dropdown Menu Example")

# Create a label
label = tk.Label(window, text="Select an item:")
label.pack()

# Create a dropdown menu
dropdown = ttk.Combobox(window, values=["בחירת מגדל מלבן", "בחירת מגדל משולש", "יציאה מהתוכנית"])
dropdown.pack()

# Set a default selection
dropdown.current(0)

# Bind the selection event
dropdown.bind("<<ComboboxSelected>>", handle_selection)

# Start the main loop
window.mainloop()





