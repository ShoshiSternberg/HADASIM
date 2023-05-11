print("Building the Twitter towers")
option = int(input("Tap 1 to select a rectangle shaped tower\n"
                   "Tap 2 to select a triangle shaped tower \nPress 3 to exit the program"))
while option!=3:
    if option!=2 and option!=1:
        print("Incorrect selection Please select again")
        continue
    width=int(input("Insert width:"))
    height=int(input("Enter height:"))

    if option==1:
        if abs(width-height)==0:
            print("Area of the square:"+width*height)
        elif abs(width-height)>5:
            print("Area of the rectangle:"+width*height)
        else:
            print("Area of the rectangle:"+width*2+height*2)

    else:
        chooze = int(input("To circle the triangle tap 1\nTo print the triangle tap"))
        if chooze==1:
            print((width * height)/2)
        if chooze==2:
            if width%2==0 or width>height*2:
                print("Unable to print the triangle")
                continue
            r=int((width-2)/2)
            h=int((height-2)/r)

            s=height-(h*r+2)
            num_spaces = (width - 1) // 2
            print(" " * num_spaces, end="")
            print('*')
            row_width=3
            for i in range(1,h+s+1):
                num_spaces = (width - row_width) // 2
                print(" " * num_spaces, end="")
                print('*'*3)

            for i in range(h+s+1,height-2,h):
                row_width=row_width+2
                for l in range(1,h+1):
                    num_spaces = (width - row_width) // 2
                    print(" " * num_spaces, end="")
                    print("*"*row_width)
            print("*"*width, end='')



    option = int(input("Tap 1 to select a rectangle shaped tower\n"
                   "Tap 2 to select a triangle shaped tower \nPress 3 to exit the program"))

print("You left the show")