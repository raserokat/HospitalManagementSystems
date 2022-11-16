# Tshegofatso Raseroka
# 2022/11/01
from serial.tools import list_ports
import serial
import time
import datetime

# Identify the correct port
ports = list_ports.comports()
for port in ports: print(port)

# Create TXT file
f = open("data.txt", "w", newline='')
f.truncate()

# Open the serial com
serialCom = serial.Serial('COM9', 9600)

# Toggle DTR to reset the Arduino
serialCom.setDTR(False)
time.sleep(1)
serialCom.flushInput()
serialCom.setDTR(True)

# How many data points to record
kmax = 4

# Loop through and collect data as it is available
for k in range(kmax):
    try:
        # Read the line
        s_bytes = serialCom.readline()
        decoded_bytes = s_bytes.decode("utf-8").rstrip("/n")
        gran = "Granted"
    #room id

        roomid=",202211"
        # time
        x = datetime.datetime.now()
        v = (x.strftime("%c"))
        if gran in decoded_bytes:
            valuesG = decoded_bytes.replace("Access Granted", ",Access Granted,")
            if valuesG != "":
                f.write(roomid+valuesG + v)
        else:
            valuesD = decoded_bytes.replace("Access Denied", ",Access Denied,")
           #f.write(roomid+valuesD + v)
    except:
        print("Error encountered, line was not recorded.")
# Close file
f.close()
