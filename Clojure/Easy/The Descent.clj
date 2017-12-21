(ns Player
  (:gen-class))

; Auto-generated code below aims at helping you parse
; the standard input according to the problem statement.

(defn highest-mountain
    [heights]
    (.indexOf heights (apply max heights)))

(defn -main [& args]
  (while true
    (let [heights (repeatedly 8 read)]
    (binding [*out* *err*]
      (println heights))
    (println(highest-mountain heights)))))
    
    ; (binding [*out* *err*]
    ;   (println "Debug messages..."))
    
    ; The number of the mountain to fire on.