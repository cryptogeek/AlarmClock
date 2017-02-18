# Download:
https://github.com/cryptogeek/AlarmClock/raw/master/source/alarmClock/bin/Release/AlarmClock.exe

# Description:
AlarmClock is a simple program to display alerts in Windows.

AlarmClock checks calendar.txt every 5 seconds to see if a line contains the current time and if it finds one, it opens calendar.txt so the user can see it.

You can see it's active by looking on the bottom right of your screen in the notification area.

# Usage:
open AlarmClock.exe and then open the file "calendar.txt" in the same folder.

You can add lines like these:

19.2 13h0  
	buy groceries:  
	-milk  
	-cereals  
	
19.2 16h45 call client back
	
# Syntax:
{day}.{month} {hour}h{minutes}

day from 1 to 31  
month from 1 to 12  
hour from 0 to 23  
minute from 0 to 59  

# Requirements:
Microsoft .NET Framework 4.5.2 or above

# Supported client OS: 
Windows Vista, 7, 8, 8.1, 10  
Windows server 2008, 2012, 2016

# Changelog:
https://raw.githubusercontent.com/cryptogeek/AlarmClock/master/changelog.txt
