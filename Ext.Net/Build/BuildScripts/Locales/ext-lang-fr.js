Date.shortMonthNames = [
   "janv.",
   "févr.",
   "mars",
   "avr.",
   "mai",
   "juin",
   "juil.",
   "août",
   "sept.",
   "oct.",
   "nov.",
   "déc."
];

Date.monthNames = [
   "janvier",
   "février",
   "mars",
   "avril",
   "mai",
   "juin",
   "juillet",
   "août",
   "septembre",
   "octobre",
   "novembre",
   "décembre"
];

Date.monthNumbers = {
  "jan" : 0,
  "fév" : 1,
  "mar" : 2,
  "avr" : 3,
  "mai" : 4,
  "juin" : 5,
  "juil" : 6,
  "aoû" : 7,
  "sep" : 8,
  "oct" : 9,
  "nov" : 10,
  "déc" : 11
};

Date.getMonthNumber = function(name) {
  var m = name.substring(0, 1).toLowerCase() + name.substring(1, 3).toLowerCase();
  if(m == "jui"){    m = name.substring(0, 1).toLowerCase() + name.substring(1, 4).toLowerCase();  }  return Date.monthNumbers[m];};

Date.dayNames = [
   "dimanche",
   "lundi",
   "mardi",
   "mercredi",
   "jeudi",
   "vendredi",
   "samedi"
];

Date.getShortDayName = function(day) {
  return Date.dayNames[day].substring(0, 3).toLowerCase() + ".";
};