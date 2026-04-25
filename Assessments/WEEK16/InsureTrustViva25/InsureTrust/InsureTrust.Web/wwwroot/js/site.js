// Auto-dismiss flash messages
document.addEventListener('DOMContentLoaded', function () {
    const flashes = document.querySelectorAll('.flash');
    flashes.forEach(f => {
        setTimeout(() => { f.style.opacity = '0'; f.style.transition = 'opacity .5s'; setTimeout(() => f.remove(), 500); }, 4000);
    });

    // Icon picker
    document.querySelectorAll('.icon-option').forEach(opt => {
        opt.addEventListener('click', function () {
            document.querySelectorAll('.icon-option').forEach(o => o.classList.remove('selected'));
            this.classList.add('selected');
            const input = document.getElementById('iconInput');
            if (input) input.value = this.dataset.icon;
        });
    });

    // Dynamic field collection on purchase form
    const purchaseForm = document.getElementById('purchaseForm');
    if (purchaseForm) {
        purchaseForm.addEventListener('submit', function (e) {
            const fields = {};
            document.querySelectorAll('[data-dynamic-field]').forEach(inp => {
                fields[inp.name] = inp.value;
            });
            document.getElementById('dynamicFieldsInput').value = JSON.stringify(fields);
        });
    }

    // Claim doc upload tracking
    document.querySelectorAll('.doc-upload-input').forEach(input => {
        input.addEventListener('change', function () {
            const item = this.closest('.claim-doc-item');
            if (item && this.files.length > 0) {
                item.classList.add('uploaded');
                item.querySelector('.doc-status').textContent = '✓ ' + this.files[0].name;
            }
            updateDocCount();
        });
    });

    // Calculator
    const calcForm = document.getElementById('calcForm');
    if (calcForm) {
        ['calc-type', 'calc-age', 'calc-cover', 'calc-tenure'].forEach(id => {
            const el = document.getElementById(id);
            if (el) el.addEventListener('input', calcEstimate);
        });
        calcEstimate();
    }
});

function updateDocCount() {
    const total = document.querySelectorAll('.doc-upload-input').length;
    const uploaded = document.querySelectorAll('.claim-doc-item.uploaded').length;
    const counter = document.getElementById('docCounter');
    if (counter) {
        counter.textContent = uploaded + ' of ' + total + ' documents uploaded';
        // Make documents optional: use neutral color and do not enforce a fixed threshold
        counter.style.color = uploaded === total && total > 0 ? '#065f46' : '#92400e';
    }
}

function calcEstimate() {
    const type = document.getElementById('calc-type')?.value || 'Term Life';
    const age = parseInt(document.getElementById('calc-age')?.value) || 30;
    const cover = parseFloat(document.getElementById('calc-cover')?.value) || 1000000;
    const tenure = parseInt(document.getElementById('calc-tenure')?.value) || 24;

    const rates = {
        'Term Life': 0.010, 'Health': 0.008, 'Vehicle': 0.015, 'Home': 0.005,
        'Property': 0.012, 'Employee Group Benefits': 0.018, 'Engineering': 0.014
    };
    const rate = rates[type] || 0.01;
    const ageFactor = 1 + (age - 30) * 0.02;
    const monthly = Math.round(cover * rate * ageFactor / 12);
    const total = monthly * tenure;

    const monthlyEl = document.getElementById('calc-monthly');
    const totalEl = document.getElementById('calc-total');
    if (monthlyEl) monthlyEl.textContent = '₹' + monthly.toLocaleString('en-IN');
    if (totalEl) totalEl.textContent = '₹' + total.toLocaleString('en-IN');
}

function confirmDelete(formId, msg) {
    if (confirm(msg || 'Are you sure?')) {
        document.getElementById(formId).submit();
    }
}

function toggleEditModal(policyId, tenure, pkg) {
    const modal = document.getElementById('editModal');
    if (modal) {
        document.getElementById('editPolicyId').value = policyId;
        document.getElementById('editTenure').value = tenure;
        document.getElementById('editPackage').value = pkg;
        modal.style.display = modal.style.display === 'flex' ? 'none' : 'flex';
    }
}

function closeModal(id) {
    const modal = document.getElementById(id);
    if (modal) modal.style.display = 'none';
}
