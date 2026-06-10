# 02-Number Wizard-llatzl

Markdown Cheatsheet: https://github.com/adam-p/markdown-here/wiki/markdown-cheatsheet

Es soll ein einfaches Number-Wizard-Spiel in Unity umgesetzt werden. Das Spiel arbeitet mit einem
Zahlenbereich und schlägt Zahlen vor. Der Spieler gibt über Buttons Hinweise, ob die gesuchte Zahl
höher, niedriger oder korrekt ist.

* **Higher:** Klicke diesen Button, wenn deine ausgedachte Zahl **höher** ist als der aktuelle Vorschlag des Computers.
* **Lower:** Klicke diesen Button, wenn deine ausgedachte Zahl **niedriger** ist als der aktuelle Vorschlag des Computers.
* **Correct:** Klicke diesen Button, wenn der Computer deine Zahl **exakt erraten** hat. Es erscheint eine Erfolgsmeldung und das Spiel wird pausiert.
* **Restart:** Dieser Button erscheint, sobald das Spiel gewonnen wurde. Ein Klick darauf setzt den Zahlenbereich zurück und startet eine neue Runde.

Der Computer rät nicht zufällig, sondern nutzt das Prinzip der **Binären Suche** (Binary Search). 
Dabei wird das Spielfeld mit jedem Tipp halbiert. Erhält der Computer beispielsweise das Feedback *Higher*, weiß er sofort, dass die gesuchte Zahl nicht in der unteren Hälfte liegen kann. Er verschiebt seine Grenzen und berechnet die goldene Mitte des verbleibenden Zahlenbereichs:
$$\text{guess} = \frac{\text{min} + \text{max}}{2}$$
Durch dieses Verfahren wird die gesuchte Zahl selbst im Bereich von 1 bis 100 in maximal 7 Versuchen garantiert gefunden.

* **Unity-Version:** 6000.0.57f1
* **Startszene:** `Assets/Scenes/02-numberwizzard-llatzl` 

--------
