import os
from setuptools import setup
setup(
    name="Codeforces Reminder",
    version="1.2",
    author="Moeen Farhadi",
    author_email="moeenfarhadi@gmail.com",
    description="Codeforces Contest Reminder",
    url="https://github.com/MoeenTM/CodeforcesReminder",
    scripts=['cfreminder',],
    license='GPLv3',
    data_files=[
        ('share/applications/', ['Codeforces Reminder.desktop']),
        ('lib/cfreminder', ['Icon.png'])],
)
