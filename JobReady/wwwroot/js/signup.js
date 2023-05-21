const activatedStep = document.querySelector(".activatedStep");
const tick1 = document.getElementById("tick1");

tick1.addEventListener("load", () => {
    if (tick1.parentElement.classList.contains("activatedStep")) {
        // Fetch the SVG file from the URL
        fetch(tick1.src)
            .then(response => response.text())
            .then(svgContent => {
                // Create a new SVG element with the fetched content
                const parser = new DOMParser();
                const svgDoc = parser.parseFromString(svgContent, 'image/svg+xml');

                // Get all the path elements within the SVG document
                const pathElements = svgDoc.querySelectorAll('path');

                // Loop through each path element and change the stroke color
                pathElements.forEach(path => {
                    path.style.stroke = '#B87333';
                });

                // Convert the modified SVG back to a string
                const modifiedSvgContent = new XMLSerializer().serializeToString(svgDoc);

                // Create a data URL from the modified SVG content
                const dataUrl = 'data:image/svg+xml;charset=utf-8,' + encodeURIComponent(modifiedSvgContent);

                // Set the data URL as the source of the image
                tick1.src = dataUrl;
            });
    }
    console.log("Hello path")
})