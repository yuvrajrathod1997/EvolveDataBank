/* Evolve DataBank - static site behaviour. No dependencies. */
(function () {
  "use strict";

  // Mobile navigation
  var toggle = document.querySelector(".nav-toggle");
  var nav = document.getElementById("site-nav");
  if (toggle && nav) {
    toggle.addEventListener("click", function () {
      var open = nav.classList.toggle("open");
      toggle.setAttribute("aria-expanded", open ? "true" : "false");
    });
  }

  var params = new URLSearchParams(window.location.search);

  // Reports page: filter the list as the person types (also reads ?q= from the home search)
  var filterInput = document.getElementById("report-filter");
  var list = document.getElementById("report-list");
  if (filterInput && list) {
    var items = Array.prototype.slice.call(list.querySelectorAll("li"));
    var empty = document.getElementById("no-results");
    var apply = function () {
      var q = filterInput.value.trim().toLowerCase();
      var shown = 0;
      items.forEach(function (li) {
        var match = !q || li.getAttribute("data-title").toLowerCase().indexOf(q) !== -1;
        li.hidden = !match;
        if (match) shown++;
      });
      if (empty) empty.hidden = shown !== 0;
    };
    filterInput.addEventListener("input", apply);
    if (params.get("q")) { filterInput.value = params.get("q"); }
    apply();
  }

  // Contact page: preselect report / request type from the query string,
  // then send the enquiry as an email (no server needed for a static site).
  var form = document.getElementById("enquiry-form");
  if (form) {
    var reportSel = form.elements["report"];
    if (reportSel && params.get("report")) { reportSel.value = params.get("report"); }
    if (params.get("type")) {
      var radio = form.querySelector('input[name="type"][value="' + params.get("type") + '"]');
      if (radio) radio.checked = true;
    }
    form.addEventListener("submit", function (e) {
      e.preventDefault();
      var f = form.elements;
      var typeEl = form.querySelector('input[name="type"]:checked');
      var reportLabel = f["report"].options[f["report"].selectedIndex].text;
      var subject = (typeEl ? typeEl.value : "Enquiry") + ": " + reportLabel;
      var body = [
        "Name: " + f["name"].value,
        "Email: " + f["email"].value,
        "Company: " + f["company"].value,
        "Country: " + f["country"].value,
        "Report: " + reportLabel,
        "",
        f["message"].value
      ].join("\n");
      // Replace with a real form endpoint when the backend is ready.
      window.location.href = "mailto:sales@evolvebi.com?subject=" +
        encodeURIComponent(subject) + "&body=" + encodeURIComponent(body);
    });
  }
})();
